using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Omf.Services.Review.Domain.Models;
using Omf.Services.Review.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Review.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly IMongoDatabase _database;
        public ReviewRepository(IMongoDatabase db)
        {
            _database = db;
        }
        public async Task AddAsync(Domain.Models.Review review)
            => await Collection.InsertOneAsync(review);

        public async Task<Domain.Models.Review> GetAsync(Guid id) => await Collection.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        private IMongoCollection<Domain.Models.Review> Collection => _database.GetCollection<Domain.Models.Review>("Reviews");
    }
}
