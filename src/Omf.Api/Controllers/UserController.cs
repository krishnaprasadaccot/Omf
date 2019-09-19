using Omf.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System.Threading.Tasks;
using Omf.Api.Repositories;
using System;

namespace Omf.Api.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IBusClient _busClient;
        private readonly IReviewRepository _reviewRepository;

        public UserController(IBusClient busClient,IReviewRepository reviewRepository)
        {
            _busClient = busClient;
            _reviewRepository = reviewRepository;
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            await _busClient.PublishAsync(command);

            return Accepted();
        }

        [HttpGet("[action]")]

        public async Task<IActionResult> GetReviews()
        {
            var reviews = await _reviewRepository.BrowseByUserAsync(Guid.Parse(User.Identity.Name));

            return Json(reviews);
        }
    }
}