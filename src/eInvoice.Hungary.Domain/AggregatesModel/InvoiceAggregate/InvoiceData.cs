using System;
using eInvoice.Hungary.Domain.SeedWork;

namespace eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate
{
    public class InvoiceData : Entity, IAggregateRoot
    {
        public Guid Guid { get; set; }
        public DateTime InvoiceDate { get; set; }

        private InvoiceData(int id)
            : base(id) { }

        private InvoiceData(Guid guid)
        {
            Guid = guid;
        }

        public InvoiceData()
        {
            Guid = Guid.NewGuid();
        }

        private InvoiceData(DateTime invoiceDate) : base()
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
