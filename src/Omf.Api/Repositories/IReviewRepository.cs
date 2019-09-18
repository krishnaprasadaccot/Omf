using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Api.Repositories
{
    public interface IReviewRepository
    {
        Task<Models.Review> GetAsync(Guid id);
        Task AddAsync(Models.Review review);
        Task<IEnumerable<Models.Review>> BrowseByUserAsync(Guid userId);
        Task<IEnumerable<Models.Review>> BrowseByRestaurantAsync(Guid restaurantId);
    }
}
