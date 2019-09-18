using Omf.Api.Repositories;
using Omf.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Api.Handlers
{
    public class ReviewCreatedHandler : IEventHandler<ReviewCreated>
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewCreatedHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task HandleAsync(ReviewCreated @event)
        {
            await _reviewRepository.AddAsync(new Models.Review
            {
                Id = @event.Id,
                UserId = @event.UserId,
                RestaurantId = @event.RestaurantId,
                Comment = @event.Comment,
                Rating = @event.Rating,
                CreatedAt = @event.CreatedAt
            });
            Console.WriteLine($"Order Created: {@event.Id}");
        }
    }
}
