using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;

namespace eInvoice.Hungary.Application.Invoices.Queries.GetInvoice
{
    public class InvoiceResult
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }

        public InvoiceResult(Invoice invoice)
        {
            Id = invoice.Id;
            InvoiceNumber = invoice.InvoiceNumber;
        }
    }
}
