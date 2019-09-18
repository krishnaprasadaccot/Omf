using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Omf.Common.Commands
{
    public class CreateOrder : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public IEnumerable<string> Items { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
