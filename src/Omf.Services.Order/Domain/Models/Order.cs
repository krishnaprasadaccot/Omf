using Omf.Common;
using Omf.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Order.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RestaurantId { get; set; }
        public IEnumerable<string> Items { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        protected Order()
        {

        }
        public Order(Guid id, Guid userId, Guid resaturantId, IEnumerable<string> items, OrderStatus status, DateTime createdAt)
        {
            if (resaturantId==null)
            {
                throw new OmfException("empty_order_restaurant", $"Order cannot be created with empty restaurant.");
            }
            Id = id;
            UserId = userId;
            RestaurantId = resaturantId;
            Items = items;
            Status = status;
            CreatedAt = createdAt;
        }
    }
}
