using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Omf.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoDatabase _database;
        public OrderRepository(IMongoDatabase db)
        {
            _database = db;
        }
        public async Task AddAsync(Order order)
        {
            if (order.Status != Common.OrderStatus.Active)
            {
                var query = Builders<Order>.Filter.Where(o => o.Id == order.Id);
                await Collection.DeleteOneAsync(query);
            }
            await Collection.InsertOneAsync(order);
        }

        public async Task<IEnumerable<Order>> BrowseAsync(Guid userId)
            => await Collection
                .AsQueryable()
                .Where(x => x.UserId == userId).ToListAsync();

        public async Task<Order> GetAsync(Guid id) => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        private IMongoCollection<Order> Collection => _database.GetCollection<Order>("Orders");
    }
}
