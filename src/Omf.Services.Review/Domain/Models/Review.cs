using Omf.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Review.Domain.Models
{
    public class Review
    {
        public Guid Id { get; protected set; }
        public string Comment { get; protected set; }
        public int Rating { get; protected set; }
        public Guid UserId { get; protected set; }
        public Guid RestaurantId { get; set; }
        public DateTime CreatedAt { get; protected set; }

        protected Review()
        {

        }
        public Review(Guid id, string comment,int rating, Guid userId,Guid restaurantId, DateTime createdAt)
        {
            if (rating <=0)
            {
                throw new OmfException("empty_review_rating", "Reiew rating cannot be empty.");
            }
            Id = id;
            Comment = comment;
            UserId = userId;
            RestaurantId = restaurantId;
            Rating = rating;
            CreatedAt = createdAt;
        }
    }
}
