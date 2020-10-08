using System.Threading.Tasks;

namespace eInvoice.Hungary.Domain.SeedWork
{
    public interface IRepository<TModel> where TModel : IEntity
    {
        IUnitOfWork UnitOfWork { get; }

        Task AddAsync(TModel model);
        void Remove(TModel model);
        void Update(TModel model);
    }
}
