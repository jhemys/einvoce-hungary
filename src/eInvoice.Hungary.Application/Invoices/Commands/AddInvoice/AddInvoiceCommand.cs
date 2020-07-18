﻿using MediatR;

namespace eInvoice.Hungary.Application.Invoices.Commands.AddInvoice
{
    public class AddInvoiceCommand : IRequest<CommandResult>
    {
        public string InvoiceNumber { get; }

        public AddInvoiceCommand(string invoiceNumber) => InvoiceNumber = invoiceNumber;
    }
}
