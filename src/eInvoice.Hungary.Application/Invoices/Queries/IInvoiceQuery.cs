using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Application.Invoices.Queries
{
    public interface IInvoiceQuery
    {
        Task<Invoice> GetInvoiceAsync(int id);
        Task<IReadOnlyCollection<Invoice>> GetInvoices();
    }
}
