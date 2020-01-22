using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using eInvoice.Hungary.Infrastructure;
using eInvoice.Hungary.Infrastructure.Seed;
using eInvoice.Hungary.Infrastructure.WriteModel.Context;

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


            host.Run();
        }

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
