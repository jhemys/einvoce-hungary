using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Domain.SeedWork
{
    public interface IReadRepository<TEntity> where TEntity : Entity<Guid>
    {
        public Task<TEntity> GetById(Guid id);
        public Task<IEnumerable<TEntity>> GetAll();
    }
}
