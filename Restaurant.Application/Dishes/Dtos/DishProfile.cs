using AutoMapper;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Dtos
{
    public class DishProfile : Profile
    {
        public DishProfile() 
        {
            CreateMap<Dish, DishDto>(); 
        }
    }
}
