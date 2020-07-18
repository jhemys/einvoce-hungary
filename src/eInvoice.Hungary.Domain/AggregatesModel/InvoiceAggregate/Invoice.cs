using eInvoice.Hungary.Domain.SeedWork;

namespace eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate
{
    public class Invoice : Entity, IAggregateRoot
    {
        public string InvoiceNumber { get; set; }

        private Invoice(int id)
            : base(id) { }

        public Invoice() { }

        private Invoice(string invoiceNumber)
        {
            InvoiceNumber = invoiceNumber;
        }

        public static Invoice Load(int id) =>
            new Invoice(id);

        public static Invoice Create(string invoiceNumber) => new Invoice(invoiceNumber);

        public Invoice Change(string invoiceNumber)
        {
            InvoiceNumber = invoiceNumber;

            return this;
        }
    }
}
