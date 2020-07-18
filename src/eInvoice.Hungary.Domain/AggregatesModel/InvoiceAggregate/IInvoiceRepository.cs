using eInvoice.Hungary.Domain.SeedWork;
using eInvoice.Hungary.Domain.Model.AggregatesModel.InvoiceAggregate;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Domain.AggregatesModel.InvoiceAggregate
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
    }
}
