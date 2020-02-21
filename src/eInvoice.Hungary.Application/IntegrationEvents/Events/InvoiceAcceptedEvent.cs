namespace eInvoice.Hungary.Application.IntegrationEvents.Events
{
    public class InvoiceAcceptedEvent : IntegrationEvent
    {
        public string InvoiceNumber { get; set; }

        public InvoiceAcceptedEvent(string invoiceNumber) => InvoiceNumber = invoiceNumber;
    }
}
