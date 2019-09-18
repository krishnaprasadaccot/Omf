using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Omf.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Api.Repositories
{
    public class ReviewRepository:IReviewRepository
    {
        private readonly IMongoDatabase _database;
        public ReviewRepository(IMongoDatabase db)
        {
            _database = db;
        }
        public async Task AddAsync(Review review)
        {
            await Collection.InsertOneAsync(review);
        }

        public async Task<IEnumerable<Review>> BrowseByUserAsync(Guid userId)
            => await Collection
                .AsQueryable()
                .Where(x => x.UserId == userId).ToListAsync();
        public async Task<IEnumerable<Review>> BrowseByRestaurantAsync(Guid restaurantId)
            => await Collection
                .AsQueryable()
                .Where(x => x.RestaurantId == restaurantId).ToListAsync();

        public async Task<Review> GetAsync(Guid id) => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        private IMongoCollection<Review> Collection => _database.GetCollection<Review>("Reviews");
    }
}
