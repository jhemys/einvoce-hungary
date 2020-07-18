using System;
using eInvoice.Hungary.Domain.SeedWork;

namespace eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate
{
    public class InvoiceData : Entity<Guid>, IAggregateRoot
    {
        public Guid Guid { get; set; }
        public DateTime InvoiceDate { get; set; }

        private InvoiceData(Guid id)
            : base(id) { }

        private InvoiceData(DateTime invoiceDate)
        {
            InvoiceDate = invoiceDate;
        }

        public static InvoiceData Load(Guid guid) =>
            new InvoiceData(guid);

        public static InvoiceData Create(DateTime invoiceDate) => new InvoiceData(invoiceDate);

        public InvoiceData Change(DateTime invoiceDate)
        {
            InvoiceDate = invoiceDate;

            return this;
        }
    }
}
