using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Omf.Services.Order.Domain.Models;
using Omf.Services.Order.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Order.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoDatabase _database;
        public OrderRepository(IMongoDatabase db)
        {
            _database = db;
        }
        public async Task AddAsync(Domain.Models.Order order)
            => await Collection.InsertOneAsync(order);

        public async Task<Domain.Models.Order> GetAsync(Guid id) => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        private IMongoCollection<Domain.Models.Order> Collection => _database.GetCollection<Domain.Models.Order>("Orders");
    }
}
