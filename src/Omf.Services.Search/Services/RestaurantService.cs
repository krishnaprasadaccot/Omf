using Omf.Services.Search.Domain.Models;
using Omf.Services.Search.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Search.Services
{
    public class RestaurantService:IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        public async Task AddAsync(Guid id, string name, string cuisine, string address, IEnumerable<object> menu, DateTime createdDate)
        {
            var restaurant = new Restaurant(id, name, cuisine, address, createdDate);
            await _restaurantRepository.AddAsync(restaurant);
        }
    }
}
