using eInvoice.Hungary.Domain.AggregatesModel.InvoiceDataAggregate;
using MediatR;
using System;

namespace eInvoice.Hungary.Application.Invoices.Commands.AddInvoice
{
    public class AddInvoiceCommand : IRequest<CommandResult>
    {
        public string InvoiceNumber { get; }
        public DateTime InvoiceDate { get; }
        public string CompanyCode { get; }
        public string ReferenceId { get; set; }
        public InvoiceData InvoiceData { get; }

        public AddInvoiceCommand(string invoiceNumber, DateTime invoiceDate, string companyCode, string referenceId, InvoiceData invoiceData)
        {
            InvoiceNumber = invoiceNumber;
            InvoiceDate = invoiceDate;
            CompanyCode = companyCode;
            ReferenceId = referenceId;
            InvoiceData = invoiceData;
        }
    }
}
