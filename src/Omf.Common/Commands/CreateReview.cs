using System;
using System.Collections.Generic;
using System.Text;

namespace Omf.Common.Commands
{
    public class CreateReview : IAuthenticatedCommand
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public Guid UserId { get; set; }
        public Guid RestaurantId { get; set; }
        public DateTime CreatedAt { get;set; }
    }
}
