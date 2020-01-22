using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace eInvoice.Hungary.Infrastructure.ReadModel.Sql
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public SqlConnectionFactory(string connectionString) => 
            _connectionString = connectionString;
        
        public IDbConnection GetConnection()
        {
            if (_connection != null && _connection.State != ConnectionState.Closed)
                return _connection;

            _connection = new SqlConnection(_connectionString);
            _connection.Open();

            return _connection;
        }
    }
}
