using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using eInvoice.Hungary.Application.Invoices;
using eInvoice.Hungary.Infrastructure.ReadModel.Queries;
using eInvoice.Hungary.Infrastructure.ReadModel.Sql;
using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Infrastructure.WriteModel.Context;
using eInvoice.Hungary.Infrastructure.WriteModel.Repositories;

namespace eInvoice.Hungary.Infrastructure
{
    public static class Startup
    {
        public static IApplicationBuilder UseAnalysisInfrastructure(IApplicationBuilder app) => app;

        public static IServiceCollection AddInvoiceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterQueryServices(services);
            RegisterRepositoryServices(services);
            RegisterSqlServices(services, configuration);

            return services;
        }

        public static IServiceCollection AddDbContextInfrastructure(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<InvoiceContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString"],
                                     sqlServerOptionsAction: sqlOptions =>
                                     {
                                         sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                         sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                     });
            });

        private static void RegisterQueryServices(IServiceCollection services)
        {
            services
                .AddScoped<IInvoiceQuery, InvoiceQuery>();
        }

        private static void RegisterRepositoryServices(IServiceCollection services)
        {
            services
                .AddScoped<IInvoiceRepository, InvoiceRepository>();
        }

        private static IServiceCollection RegisterSqlServices(IServiceCollection services, IConfiguration configuration) =>
            services.AddScoped<ISqlConnectionFactory>(_ => new SqlConnectionFactory(configuration["ConnectionString"]));
    }
}
