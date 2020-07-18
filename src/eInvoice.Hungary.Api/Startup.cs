using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using eInvoice.Hungary.Infrastructure;
using MediatR;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using eInvoice.Hungary.Application.IntegrationEvents;
using eInvoice.Hungary.Application.IntegrationEvents.Events;
using eInvoice.Hungary.Application.IntegrationEvents.EventHandling;

namespace eInvoice.Hungary.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Hungary e-Invoice", Version = "v1" });
            });

            services.AddDbContextInfrastructure(Configuration);
            services.AddMongoDbConnection(Configuration);
            services.AddInvoiceInfrastructure(Configuration);
            services.AddIntegrationService(Configuration);
            services.AddEventBus(Configuration);

            services.AddTransient<InvoiceAcceptedEventHandler>();

            Assembly[] applicationAssembly = { AppDomain.CurrentDomain.Load("eInvoice.Hungary.Application") };

            services.AddMediatR(applicationAssembly);

            var container = new ContainerBuilder();
            container.Populate(services);

            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI(v1)");
            });

            ConfigureEventBus(app);
        }

        protected virtual void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<InvoiceAcceptedEvent, InvoiceAcceptedEventHandler>();
        }
    }
}
