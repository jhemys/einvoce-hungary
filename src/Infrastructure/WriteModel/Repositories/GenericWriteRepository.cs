using eInvoice.Hungary.Domain.SeedWork;
using eInvoice.Hungary.Infrastructure.WriteModel.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Infrastructure.WriteModel.Repositories
{
    public class GenericWriteRepository<T> : DbContext, IRepository<T> where T : IEntity
    {
        private SqlContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;
        public GenericWriteRepository(SqlContext dbContext)
            => _dbContext = dbContext ?? throw new ArgumentNullException($"'{nameof(dbContext)}'");

        public async Task AddAsync(T model)
        {
            await _dbContext.AddAsync(model);
        }

        public void Remove(T model)
        {
            _dbContext.Attach(model);
            _dbContext.Remove(model);
        }

        public void Update(T model)
        {
            _dbContext.Attach(model);
            _dbContext.Entry(model).State = EntityState.Modified;
        }
    }
}
