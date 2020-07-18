using eInvoice.Hungary.Domain.SeedWork;
using eInvoice.Hungary.Infrastructure.NoSQL.Abstractions;
using System;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Infrastructure.NoSQL.Context
{
    class UnitOfWorkNoSql : IUnitOfWork
    {
        private readonly IMongoContext _context;

        public UnitOfWorkNoSql(IMongoContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task SaveEntitiesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
