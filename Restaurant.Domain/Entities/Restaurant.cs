using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Domain.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = default!;

        [MaxLength(300)]
        public string Description { get; set; } = default!;

        [MaxLength(100)]
        public string Category { get; set; } = default!;

        public bool HasDelivery {  get; set; }

        [MaxLength(100)]
        public string? ContactEmail { get; set; }

        [MaxLength(20)]
        public string? ContactNumber { get; set; }
        
        public Address? Address { get; set; }

        public List<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
