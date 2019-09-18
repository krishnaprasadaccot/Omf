using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Search.Domain.Models
{
    public class Dish
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public float Price { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
    }
}
