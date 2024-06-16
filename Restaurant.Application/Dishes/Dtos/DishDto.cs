﻿using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Dtos
{
    public class DishDto
    {
        public int ID { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int? KiloCalories { get; set; }

        public static DishDto FromEntity(Dish dish)
        {
            return new DishDto
            {
                ID = dish.ID,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                KiloCalories = dish.KiloCalories,
            };
        }

    }
}
