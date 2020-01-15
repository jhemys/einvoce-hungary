using eInvoice.Hungary.Api.Infrastructure;
using eInvoice.Hungary.Api.Infrastructure.Seed;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace eInvoice.Hungary.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = GetConfiguration();

            var host = BuildWebHost(configuration, args);

            host.MigrateDbContext<InvoiceContext>((context, services) =>
            {
                var env = services.GetService<IHostingEnvironment>();
                var settings = services.GetService<IOptions<InvoiceSettings>>();
                var logger = services.GetService<ILogger<InvoiceContextSeed>>();

                new InvoiceContextSeed()
                    .SeedAsync(context, env, settings, logger)
                    .Wait();
            });

            //CreateHostBuilder(args).Build().Run();

            host.Run();
            //new InvoiceContextSeed.SeedAsync(app)
            //    .Wait();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        private static IWebHost BuildWebHost(IConfiguration configuration, string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .CaptureStartupErrors(false)
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseWebRoot("Pics")
                .UseConfiguration(configuration)
                .Build();

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            return builder.Build();
        }
    }
}
