using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using eInvoice.Hungary.Infrastructure.ReadModel.Queries;
using eInvoice.Hungary.Infrastructure.ReadModel.Sql;
using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Infrastructure.WriteModel.Context;
using eInvoice.Hungary.Infrastructure.WriteModel.Repositories;
using eInvoice.Hungary.Infrastructure.EventBus.Abstractions;
using eInvoice.Hungary.Infrastructure.EventBus;
using Autofac;
using RabbitMQ.Client;
using Microsoft.Extensions.Logging;
using eInvoice.Hungary.Application.IntegrationEvents;
using eInvoice.Hungary.Application.Invoices.Queries;
using eInvoice.Hungary.Infrastructure.NoSQL.Abstractions;
using eInvoice.Hungary.Domain.SeedWork;
using eInvoice.Hungary.Infrastructure.NoSQL.Context;
using eInvoice.Hungary.Domain.AggregatesModel.InvoiceDataAggregate;
using eInvoice.Hungary.Application.Storage;
using eInvoice.Hungary.Infrastructure.Storage.Firebase;

namespace eInvoice.Hungary.Infrastructure
{
    public static class Startup
    {
        public static IApplicationBuilder UseEInvoiceInfrastructure(IApplicationBuilder app) => app;

        public static IServiceCollection AddInvoiceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterQueryServices(services);
            RegisterRepositoryServices(services);
            RegisterSqlServices(services, configuration);

            return services;
        }

        public static IServiceCollection AddDbContextInfrastructure(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<SqlContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString"],
                                     sqlServerOptionsAction: sqlOptions =>
                                     {
                                         sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                         sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                     });
            });

        public static IServiceCollection AddMongoDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWorkNoSql>();

            return services;
        }

        public static IServiceCollection AddIntegrationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRabbitMQConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<RabbitMQConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = configuration["EventBusConnection"],
                    DispatchConsumersAsync = true
                };

                if (!string.IsNullOrEmpty(configuration["EventBusUserName"]))
                {
                    factory.UserName = configuration["EventBusUserName"];
                }

                if (!string.IsNullOrEmpty(configuration["EventBusPassword"]))
                {
                    factory.Password = configuration["EventBusPassword"];
                }

                var retryCount = 5;
                if (!string.IsNullOrEmpty(configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(configuration["EventBusRetryCount"]);
                }

                return new RabbitMQConnection(factory, logger, retryCount);
            });

            services.AddSingleton<IStorage>(storage =>
            {
                return new FirebaseCloudStorage(configuration["FirebaseStorageBucket"]);
            });

            return services;
        }

        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            var subscriptionClientName = configuration["SubcriptionClientName"] ?? "eInvoice";

            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistedConnection = sp.GetRequiredService<IRabbitMQConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubscriptionManager = sp.GetRequiredService<IEventBusSubscriptionManager>();

                var retryCount = 5;
                if (!string.IsNullOrEmpty(configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(configuration["EventBusRetryCount"]);
                }

                return new EventBusRabbitMQ(rabbitMQPersistedConnection,
                                            logger,
                                            iLifetimeScope,
                                            eventBusSubscriptionManager,
                                            subscriptionClientName,
                                            retryCount);
            });

            services.AddSingleton<IEventBusSubscriptionManager, InMemoryEventBusSubscriptionManager>();

            return services;
        }


        private static void RegisterQueryServices(IServiceCollection services)
        {
            services.AddScoped<IInvoiceQuery, InvoiceQuery>();
        }

        private static void RegisterRepositoryServices(IServiceCollection services)
        {
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceDataReferenceRepository, InvoiceDataReferenceRepository>();
            services.AddScoped<IInvoiceDataRepository, InvoiceDataRepository>();
        }

        private static IServiceCollection RegisterSqlServices(IServiceCollection services, IConfiguration configuration) =>
            services.AddScoped<ISqlConnectionFactory>(_ => new SqlConnectionFactory(configuration["ConnectionString"]));
    }
}
