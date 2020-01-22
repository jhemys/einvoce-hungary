using eInvoice.Hungary.Domain.SeedWork;
using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task Add(Invoice invoice);
    }
}
