using System;
using System.Collections.Generic;
using System.Text;

namespace eInvoice.Hungary.Infrastructure.NoSQL.Abstractions
{
    public interface INoSqlConnectionSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
