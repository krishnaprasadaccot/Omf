using Omf.Common.Commands;
using Omf.Common.Events;
using Omf.Common.Exceptions;
using Omf.Services.Review.Services;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Review.Handlers
{
    public class CreateReviewHandler : ICommandHandler<CreateReview>
    {
        private IBusClient _busClient;
        private readonly IReviewService _reviewService;

        public CreateReviewHandler(IBusClient busClient, IReviewService reviewService)
        {
            _busClient = busClient;
            _reviewService = reviewService;

        }
        public async Task HandleAsync(CreateReview command)
        {
            Console.WriteLine($"Creating Review: {command.Comment}");
            try
            {
                await _reviewService.AddAsync(command.Id, command.UserId,command.RestaurantId, command.Comment, command.Rating, command.CreatedAt);
                await _busClient.PublishAsync(new ReviewCreated(command.Id, command.UserId,command.RestaurantId, command.Comment, command.Rating, command.CreatedAt));
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
