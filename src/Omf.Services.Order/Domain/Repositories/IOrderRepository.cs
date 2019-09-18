using Omf.Services.Order.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Order.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Models.Order> GetAsync(Guid id);
        Task AddAsync(Models.Order order);
    }
}
