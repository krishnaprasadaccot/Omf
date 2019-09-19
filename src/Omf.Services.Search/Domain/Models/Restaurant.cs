using Omf.Common.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omf.Services.Search.Domain.Models
{
    public class Restaurant
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Cuisine { get; protected set; }
        public string Address { get; protected set; }
        public IEnumerable<Dish> Menu { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected Restaurant()
        {

        }
        public Restaurant(Guid id, string name, string cuisine, string address, DateTime createdDate)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new OmfException("empty_restaurant_name", $"Restaurant name cannot be empty.");
            }
            Id = id;
            Name = name;
            Cuisine = cuisine;
            Address = address;
            CreatedAt = createdDate;
        }
    }
}
