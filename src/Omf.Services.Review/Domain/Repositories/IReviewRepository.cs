using Omf.Services.Review.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Review.Domain.Repositories
{
    public interface IReviewRepository
    {
        Task<Models.Review> GetAsync(Guid id);
        Task AddAsync(Models.Review activity);
    }
}
