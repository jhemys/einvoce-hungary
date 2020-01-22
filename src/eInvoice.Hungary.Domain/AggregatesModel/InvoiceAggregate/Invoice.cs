using eInvoice.Hungary.Domain.SeedWork;

namespace eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate
{
    public class Invoice : Entity, IAggregateRoot
    {
        public string InvoiceNumber { get; set; }
    }
}
