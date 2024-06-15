using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Repositories
{
    public class RestaurantsRepository(RestaurantDbContext _context) : IRestaurantsRepository
    {
        public async Task<IEnumerable<Restaurant>> GetRestaurantsAsync()
        {
            var restaurants = await _context.Restaurants.ToListAsync();
            return restaurants;
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            return restaurant;
        }
    }
}
