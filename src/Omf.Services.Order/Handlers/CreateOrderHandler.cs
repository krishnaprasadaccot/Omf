using Omf.Common.Commands;
using Omf.Common.Events;
using Omf.Common.Exceptions;
using Omf.Services.Order.Services;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Order.Handlers
{
    public class CreateOrderHandler : ICommandHandler<CreateOrder>
    {
        private IBusClient _busClient;
        private readonly IOrderService _orderService;

        public CreateOrderHandler(IBusClient busClient, IOrderService orderService)
        {
            _busClient = busClient;
            _orderService = orderService;

        }
        public async Task HandleAsync(CreateOrder command)
        {
            Console.WriteLine($"Creating Order for UserId {command.UserId} at restaurant {command.RestaurantId}");
            try
            {
                await _orderService.AddAsync(command.Id, command.UserId, command.RestaurantId, command.Items, command.Status, command.CreatedAt);
                await _busClient.PublishAsync(new OrderCreated(command.Id, command.UserId, command.RestaurantId, command.Items, command.Status, command.CreatedAt));
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
