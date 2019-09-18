using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Omf.Common;
using Omf.Services.Order.Domain.Repositories;

namespace Omf.Services.Order.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task AddAsync(Guid id, Guid userId, Guid resaturantId, IEnumerable<string> items, OrderStatus status, DateTime createdAt)
        {            
            var order = new Order.Domain.Models.Order(id, userId, resaturantId, items, status, createdAt);
            await _orderRepository.AddAsync(order);
        }
    }
}
