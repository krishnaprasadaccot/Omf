using Omf.Services.Search.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Search.Domain.Repositories
{
    public interface IRestaurantRepository
    {
        Task<Restaurant> GetAsync(Guid id);
        Task AddAsync(Restaurant activity);
    }
}
