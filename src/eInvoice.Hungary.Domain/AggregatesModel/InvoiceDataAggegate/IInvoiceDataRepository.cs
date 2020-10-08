using eInvoice.Hungary.Domain.SeedWork;

namespace eInvoice.Hungary.Domain.AggregatesModel.InvoiceDataAggregate
{
    public interface IInvoiceDataRepository : IReadRepository<InvoiceData>, IRepository<InvoiceData>
    {

    }
}
