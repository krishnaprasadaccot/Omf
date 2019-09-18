using Omf.Common.Exceptions;
using Omf.Services.Review.Domain.Models;
using Omf.Services.Review.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Review.Services
{
    public class ReviewService:IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task AddAsync(Guid id, Guid userId,Guid restaurantId, string comment, int rating, DateTime createdDate)
        {
            var review = new Domain.Models.Review(id, comment,rating, userId,restaurantId,  createdDate);
            await _reviewRepository.AddAsync(review);
        }
    }
}
