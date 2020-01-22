namespace eInvoice.Hungary.Domain.SeedWork
{
    public interface IRepository<TModel> where TModel : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
