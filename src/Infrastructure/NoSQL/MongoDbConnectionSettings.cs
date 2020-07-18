using eInvoice.Hungary.Infrastructure.NoSQL.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace eInvoice.Hungary.Infrastructure.NoSQL
{
    public class MongoDbConnectionSettings : INoSqlConnectionSettings
    {

        private readonly ILogger<MongoDbConnectionSettings> _logger;

        public MongoDbConnectionSettings(string connection, string databaseName, ILogger<MongoDbConnectionSettings> logger)
        {
            _logger = logger;
            ConnectionString = connection;
            DatabaseName = databaseName;
        }

        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
