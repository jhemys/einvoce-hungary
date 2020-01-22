using System.Threading.Tasks;

namespace eInvoice.Hungary.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task SaveEntitiesAsync();
    }
}
