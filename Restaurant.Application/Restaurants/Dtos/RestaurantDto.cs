﻿using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Dtos
{
    public class RestaurantDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string Category { get; set; } = default!;

        public bool HasDelivery { get; set; }

        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }

        public List<DishDto> Dishes { get; set; } = new();

        public static RestaurantDto FromEntity(Restaurant? restaurant)
        {
            if (restaurant is null)
                return null;
            return new RestaurantDto
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Description = restaurant.Description,
                Category = restaurant.Category,
                City = restaurant.Address?.City,
                Street = restaurant.Address?.Street,
                PostalCode = restaurant.Address?.PostalCode,
            };
        }
    }
}
