using MediatR;
using System;

namespace eInvoice.Hungary.Application.Invoices.Commands.AddInvoice
{
    public class AddInvoiceCommand : IRequest<CommandResult>
    {
        public string InvoiceNumber { get; }
        public DateTime InvoiceDate { get; }

        public AddInvoiceCommand(string invoiceNumber, DateTime invoiceDate)
        {
            InvoiceNumber = invoiceNumber;
            InvoiceDate = invoiceDate;
        }
    }
}
