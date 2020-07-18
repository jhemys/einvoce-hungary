using MediatR;

namespace eInvoice.Hungary.Application.Invoices.Commands.UpdateInvoice
{
    public class UpdateInvoiceCommand : IRequest<CommandResult>
    {
        public int InvoiceId { get; }
        public string InvoiceNumber { get; }

        public UpdateInvoiceCommand(int invoiceId, string invoiceNumber)
        {
            InvoiceId = invoiceId;
            InvoiceNumber = invoiceNumber;
        }
    }
}
