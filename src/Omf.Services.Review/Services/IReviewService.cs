using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Review.Services
{
    public interface IReviewService
    {
        Task AddAsync(Guid id, Guid userId,Guid restaurantId, string comment, int rating,DateTime createdDate);
    }
}
