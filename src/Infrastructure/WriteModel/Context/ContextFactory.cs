using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eInvoice.Hungary.Infrastructure.WriteModel.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<SqlContext>
    {
        private IConfiguration Configuration;
        public ContextFactory()
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(Configuration.GetSection("ConnectionString").Value);
        }

        public ContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public SqlContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("ConnectionString"));

            var connection = Configuration["ConnectionString"];

            var builder = new DbContextOptionsBuilder<SqlContext>();
            builder.UseSqlServer(configuration.GetSection("ConnectionString").Value);

            return new SqlContext(builder.Options);
        }
    }
}
