using eInvoice.Hungary.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Infrastructure.WriteModel.Repositories
{
    public class GenericWriteRepository<T> : DbContext, IRepository<T> where T : IAggregateRoot
    {
        private IUnitOfWork _unitOfWork;
        private DbContext _dbContext;
        public GenericWriteRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException($"'{nameof(unitOfWork)}'");
            //_dbContext = unitOfWork;
        }

        public IUnitOfWork UnitOfWork => _unitOfWork;

        public async Task AddAsync(T model)
        {
            //await  .AddAsync(invoice);
        }

        public void Remove(T model)
        {
            throw new NotImplementedException();
        }

        public void Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
