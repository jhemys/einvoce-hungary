using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace eInvoice.Hungary.Application.Invoices.Commands.DeleteInvoice
{
    public class DeleteInvoiceCommand : IRequest<CommandResult>
    {
        public int InvoiceId { get; }

        public DeleteInvoiceCommand(int invoiceId) => InvoiceId = invoiceId;
    }
}
