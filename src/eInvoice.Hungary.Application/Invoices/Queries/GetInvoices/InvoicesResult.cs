using eInvoice.Hungary.Application.Invoices.Queries.GetInvoice;
using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;
using System.Collections.Generic;

namespace eInvoice.Hungary.Application.Invoices.Queries.GetInvoices
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
