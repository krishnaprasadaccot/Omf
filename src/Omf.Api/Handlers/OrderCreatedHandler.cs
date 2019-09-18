using Omf.Api.Repositories;
using Omf.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Api.Handlers
{
    public class OrderCreatedHandler: IEventHandler<OrderCreated>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderCreatedHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task HandleAsync(OrderCreated @event)
        {
            await _orderRepository.AddAsync(new Models.Order
            {
                Id = @event.Id,
                UserId = @event.UserId,
                RestaurantId = @event.RestaurantId,
                Items = @event.Items,
                Status = @event.Status,
                CreatedAt = @event.CreatedAt
            });
            Console.WriteLine($"Order Created: {@event.Id}");
        }
    }
}
