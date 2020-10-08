using eInvoice.Hungary.Domain.SeedWork;

namespace eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate
{
    public enum InvoiceStatus
    {
        Received = 1,
        Mapped = 2,
        Transmitted = 3,
        Approved = 4,
        Rejected = 5,
        Pending = 6,
        Error = 999
    }
}
