using Dapper;
using eInvoice.Hungary.Application.Invoices.Queries;
using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Infrastructure.ReadModel.Sql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Infrastructure.ReadModel.Queries
{
    public class InvoiceDataReferenceQuery : IInvoiceDataReferenceQuery
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public InvoiceDataReferenceQuery(ISqlConnectionFactory connectionFactory)
            => _connectionFactory = connectionFactory;

        public async Task<InvoiceDataReference> GetInvoiceDataReferenceByInvoiceDataId(Guid invoiceDataId)
        {
            using var connection = _connectionFactory.GetConnection();
            var invoiceQuery = @"SELECT * FROM InvoiceDataReference A INNER JOIN Invoice B ON A.InvoiceId = B.InvoiceId WHERE A.InvoiceDataId = @InvoiceDataId";
            var invoiceDataReferenceResult = await connection.QueryFirstOrDefaultAsync<InvoiceDataReference>(
                new CommandDefinition(invoiceQuery, new { InvoiceDataId = invoiceDataId }));

            return invoiceDataReferenceResult;
        }
    }
}
