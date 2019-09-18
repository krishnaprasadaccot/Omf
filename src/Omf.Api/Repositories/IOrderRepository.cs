using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Api.Repositories
{
    public interface IOrderRepository
    {
        Task<Models.Order> GetAsync(Guid id);
        Task AddAsync(Models.Order order);
        Task<IEnumerable<Models.Order>> BrowseAsync(Guid userId);
    }
}
