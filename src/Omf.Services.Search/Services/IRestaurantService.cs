using Omf.Services.Search.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Search.Services
{
    public interface IRestaurantService
    {
        Task AddAsync(Guid id, string name, string cuisine, string address, IEnumerable<Dish> menu, DateTime createdDate);
    }
}
