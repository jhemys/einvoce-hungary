using eInvoice.Hungary.Domain.AggregatesModel.InvoiceDataAggregate;
using System;

namespace eInvoice.Hungary.Application.IntegrationEvents.Events
{
    public class InvoiceReceivedEvent : IntegrationEvent
    {
        public string InvoiceNumber { get; }
        public DateTime InvoiceDate { get; }
        public string CompanyCode { get; }
        public string ReferenceId { get; set; }
        public InvoiceData InvoiceData { get; }

        public InvoiceReceivedEvent(string invoiceNumber, DateTime invoiceDate, string companyCode, string referenceId, InvoiceData invoiceData)
        {
            InvoiceNumber = invoiceNumber;
            InvoiceDate = invoiceDate;
            CompanyCode = companyCode;
            ReferenceId = referenceId;
            InvoiceData = invoiceData;
        }
    }
}
