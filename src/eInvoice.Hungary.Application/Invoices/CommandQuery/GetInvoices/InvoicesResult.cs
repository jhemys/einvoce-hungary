using eInvoice.Hungary.Application.Invoices.CommandQuery.GetInvoice;
using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace eInvoice.Hungary.Application.Invoices.CommandQuery.GetInvoices
{
    public class InvoicesResult
    {
        public List<InvoiceResult> Invoices { get; }

        private InvoicesResult() => Invoices = new List<InvoiceResult>();

        public InvoicesResult(IEnumerable<Invoice> invoices)
            : this()
        {
            foreach (var invoice in invoices)
                Invoices.Add(new InvoiceResult(invoice));
        }
    }
}
