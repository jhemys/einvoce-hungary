using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Application.Invoices
{
    public interface IInvoiceQuery
    {
        Task<Invoice> GetInvoiceAsync(int id);
        Task<IReadOnlyCollection<Invoice>> GetInvoices();
    }
}
