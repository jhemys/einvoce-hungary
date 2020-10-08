using System;

namespace eInvoice.Hungary.Api.Models
{
    public class InvoiceModel
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string CompanyCode { get; set; }
        public string ReferenceId { get; set; }
        public InvoiceDataModel InvoiceData { get; set; }
    }
}
