using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Omf.Services.Search.Domain.Models;
using Omf.Services.Search.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Search.Repositories
{
    public class RestaurantRepository:IRestaurantRepository
    {
        private readonly IMongoDatabase _database;
        public RestaurantRepository(IMongoDatabase db)
        {
            _database = db;
        }
        public async Task AddAsync(Restaurant restaurant)
            => await Collection.InsertOneAsync(restaurant);

        public async Task<Restaurant> GetAsync(Guid id) => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        private IMongoCollection<Restaurant> Collection => _database.GetCollection<Restaurant>("Restaurants");
    }
}
