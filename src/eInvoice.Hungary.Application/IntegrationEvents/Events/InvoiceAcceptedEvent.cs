using System;

namespace eInvoice.Hungary.Application.IntegrationEvents.Events
{
    public class InvoiceAcceptedEvent : CallbackEvent
    {
        public string ReferenceId { get; set; }
        public Guid InvoiceDataId { get; set; }

        public InvoiceAcceptedEvent() : base("test.com", Guid.NewGuid().ToString()) { }
        public InvoiceAcceptedEvent(string referenceId, Guid invoiceDataId) : base("test.com", Guid.NewGuid().ToString())
        {
            ReferenceId = referenceId;
            InvoiceDataId = invoiceDataId;
        }
    }
}
