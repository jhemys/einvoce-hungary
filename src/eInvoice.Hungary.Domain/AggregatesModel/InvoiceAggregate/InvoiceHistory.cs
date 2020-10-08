using eInvoice.Hungary.Domain.SeedWork;
using System;

namespace eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate
{
    public class InvoiceHistory : Entity<int>
    {
        public Invoice Invoice { get; set; }
        public InvoiceDataReference InvoiceDataReference { get; set; }
        public InvoiceStatus Status { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public InvoiceHistory()
        {
        }
    }
}
