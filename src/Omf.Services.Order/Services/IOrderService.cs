using Omf.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Order.Services
{
    public interface IOrderService
    {
        Task AddAsync(Guid id, Guid userId, Guid resaturantId, IEnumerable<string> items, OrderStatus status, DateTime createdAt);
    }
}
