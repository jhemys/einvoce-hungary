using eInvoice.Hungary.Domain.SeedWork;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Infrastructure.NoSQL.Abstractions
{
    public interface IMongoContext : IDisposable, IUnitOfWork
    {
        void AddCommand(Func<Task> func);
        Task<int> SaveChanges();
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
