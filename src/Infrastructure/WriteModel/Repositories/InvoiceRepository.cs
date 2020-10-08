using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Infrastructure.WriteModel.Context;

namespace eInvoice.Hungary.Infrastructure.WriteModel.Repositories
{
    public class InvoiceRepository : GenericWriteRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(SqlContext invoiceContext) : base(invoiceContext) { }
    }
}
