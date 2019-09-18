using System;
using System.Collections.Generic;
using System.Text;

namespace Omf.Common.Events
{
    public class OrderCreated: IAuthenticatedEvent
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public IEnumerable<string> Items { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        protected OrderCreated()
        {

        }
        public OrderCreated(Guid id, Guid userId, Guid resaturantId, IEnumerable<string> items, OrderStatus status, DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            RestaurantId = resaturantId;
            Items = items;
            Status = status;
            CreatedAt = createdAt;
        }
    }
}
