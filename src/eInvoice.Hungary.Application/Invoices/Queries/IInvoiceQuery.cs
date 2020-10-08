using eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Application.Invoices.Queries
{
    public interface IInvoiceQuery
    {
        Task<Invoice> GetInvoice(int id);
        Task<IReadOnlyCollection<Invoice>> GetInvoices();
        Task<Invoice> GetInvoiceByReferenceId(string referenceId);
    }
}
