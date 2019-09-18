using System;
using System.Collections.Generic;
using System.Text;

namespace Omf.Common.Events
{
    public class ReviewCreated:IAuthenticatedEvent
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public Guid UserId { get; set; }
        public Guid RestaurantId { get; set; }
        public DateTime CreatedAt { get; set; }

        protected ReviewCreated()
        {

        }
        public ReviewCreated(Guid id, Guid userId, Guid restaurantId, string comment, int rating, DateTime createdDate)
        {
            Id = id;
            UserId = userId;
            RestaurantId = restaurantId;
            Comment = comment;
            Rating = rating;
            CreatedAt = createdDate;
        }
    }
}
