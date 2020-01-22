using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace eInvoice.Hungary.Application.Invoices.CommandQuery.GetInvoice
{
    public class InvoiceResult
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }

        public InvoiceResult(Invoice invoice)
        {
            Id = invoice.Id;
            InvoiceNumber = invoice.InvoiceNumber;
        }
    }
}
