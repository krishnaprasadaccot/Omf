using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omf.Api.Repositories;
using Omf.Common.Commands;
using RawRabbit;

namespace Omf.Api.Controllers
{
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly IOrderRepository _orderRepository;
        public OrderController(IBusClient busClient, IOrderRepository orderRepository)
        {
            _busClient = busClient;
            _orderRepository = orderRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateOrder command)
        {
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;
            command.UserId = Guid.Parse(User.Identity.Name);
            await _busClient.PublishAsync(command);

            return Accepted($"orders/{command.Id}");
        }
        [HttpGet("")]

        public async Task<IActionResult> Get()
        {
            var orders = await _orderRepository.BrowseAsync(Guid.Parse(User.Identity.Name));

            return Json(orders);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(Guid id)
        {
            var order = await _orderRepository.GetAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            if (order.UserId != Guid.Parse(User.Identity.Name))
            {
                return Unauthorized();
            }
            return Json(order);
        }
    }
}