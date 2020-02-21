using Dapper;
using eInvoice.Hungary.Application.Invoices.Queries;
using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Infrastructure.ReadModel.Sql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Infrastructure.ReadModel.Queries
{
    public class InvoiceQuery : IInvoiceQuery
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public InvoiceQuery(ISqlConnectionFactory connectionFactory)
            => _connectionFactory = connectionFactory;

        public async Task<Invoice> GetInvoiceAsync(int id)
        {
            using var connection = _connectionFactory.GetConnection();
            var invoiceQuery = @"SELECT * FROM Invoices WHERE Id = @Id";
            var invoiceResult = await connection.QueryFirstOrDefaultAsync<Invoice>(
                new CommandDefinition(invoiceQuery, new { Id = id }));

            return invoiceResult;
        }

        public async Task<IReadOnlyCollection<Invoice>> GetInvoices()
        {
            using var connection = _connectionFactory.GetConnection();
            var invoiceQuery = @"SELECT * FROM Invoices";
            var invoicesResult = await connection.QueryAsync<Invoice>(
                new CommandDefinition(invoiceQuery));

            return (IReadOnlyCollection<Invoice>)invoicesResult;
        }
    }
}
