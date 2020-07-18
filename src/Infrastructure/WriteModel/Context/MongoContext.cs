﻿using eInvoice.Hungary.Domain.SeedWork;
using eInvoice.Hungary.Infrastructure.NoSQL.Abstractions;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eInvoice.Hungary.Infrastructure.WriteModel.Context
{
    public class MongoContext : IMongoContext, IUnitOfWork
    {
        private IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoClient MongoClient { get; set; }
        private readonly List<Func<Task>> _commands;
        private readonly IConfiguration _configuration;

        public MongoContext(IConfiguration configuration)
        {
            _configuration = configuration;

            // Every command will be stored and it'll be processed at SaveChanges
            _commands = new List<Func<Task>>();
        }



        public async Task<int> SaveChanges()
        {
            ConfigureMongo();

            using (Session = await MongoClient.StartSessionAsync())
            {
                Session.StartTransaction();

                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);

                await Session.CommitTransactionAsync();
            }

            return _commands.Count;
        }

        private void ConfigureMongo()
        {
            if (MongoClient != null)
                return;

            // Configure mongo (You can inject the config, just to simplify)
            MongoClient = new MongoClient(_configuration["MongoDbConnectionSettings:ConnectionString"]);

            Database = MongoClient.GetDatabase(_configuration["MongoDbConnectionSettings:DatabaseName"]);

        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            ConfigureMongo();
            return Database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }

        public Task SaveEntitiesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
