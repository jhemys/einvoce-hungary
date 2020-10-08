using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using eInvoice.Hungary.Infrastructure.WriteModel.Context;

namespace eInvoice.Hungary.Infrastructure.WriteModel.Repositories
{
    public class InvoiceDataReferenceRepository : GenericWriteRepository<InvoiceDataReference>, IInvoiceDataReferenceRepository
    {
        public InvoiceDataReferenceRepository(SqlContext invoiceDataReferenceContext) : base(invoiceDataReferenceContext) { }
    }
}
