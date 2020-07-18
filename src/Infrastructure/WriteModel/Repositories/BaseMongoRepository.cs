using eInvoice.Hungary.Domain.SeedWork;
using eInvoice.Hungary.Infrastructure.NoSQL.Abstractions;
using MongoDB.Driver;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Infrastructure.WriteModel.Repositories
{
    public abstract class BaseMongoRepository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
    {
        protected readonly IMongoContext Context;
        protected IMongoCollection<TEntity> DbSet;

        public IUnitOfWork UnitOfWork => Context;

        protected BaseMongoRepository(IMongoContext context)
        {
            Context = context ?? throw new ArgumentNullException($"'{nameof(context)}'");
        }

        public virtual void Add(TEntity obj)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }

        private void ConfigDbSet()
        {
            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            ConfigDbSet();
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            ConfigDbSet();
            var all = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual void Update(TEntity obj)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId()), obj));
        }

        public virtual void Remove(Guid id)
        {
            ConfigDbSet();
            Context.AddCommand(() => DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

        public Task AddAsync(TEntity model)
        {
            ConfigDbSet();
            return DbSet.InsertOneAsync(model);
        }

        public void Remove(TEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
