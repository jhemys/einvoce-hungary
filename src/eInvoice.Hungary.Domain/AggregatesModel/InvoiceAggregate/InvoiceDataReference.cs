using System;
using System.ComponentModel.DataAnnotations.Schema;
using eInvoice.Hungary.Domain.AggregatesModel.InvoiceDataAggregate;
using eInvoice.Hungary.Domain.SeedWork;

namespace eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate
{
    public class InvoiceDataReference : Entity<int>
    {
        public DateTime Date { get; set; }
        public Guid InvoiceDataId { get; set; }
        public Invoice Invoice { get; set; }

        [NotMapped]
        public InvoiceData InvoiceData { get; set; }

        private InvoiceDataReference(int id)
            : base(id) { }

        private InvoiceDataReference(Invoice invoice, Guid invoiceDataId, DateTime? date)
        {
            Date = date ?? DateTime.UtcNow;
            InvoiceDataId = invoiceDataId;
            Invoice = invoice;
        }

        public InvoiceDataReference() { }

        public static InvoiceDataReference Create(Invoice invoice, Guid invoicedataId, DateTime? date = null) => new InvoiceDataReference(invoice, invoicedataId, date);
        public InvoiceDataReference Change(Guid invoicedataId)
        {
            InvoiceDataId = invoicedataId;

            return this;
        }
    }
}
