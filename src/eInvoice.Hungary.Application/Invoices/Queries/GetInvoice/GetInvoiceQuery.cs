using MediatR;

namespace eInvoice.Hungary.Application.Invoices.Queries.GetInvoice
{
    public class GetInvoiceQuery : IRequest<InvoiceResult>
    {
        public int InvoiceId { get; }

        public GetInvoiceQuery(int invoiceId)
        {
            InvoiceId = invoiceId;
        }
    }
}
