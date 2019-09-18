using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Api.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public Guid RestaurantId { get; set; }
        public int Rating { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
