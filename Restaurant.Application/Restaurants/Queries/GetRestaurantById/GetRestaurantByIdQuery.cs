using MediatR;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuery : IRequest<RestaurantDto>
    {
        public int Id { get; }

        public GetRestaurantByIdQuery(int id)
        {
            Id = id;
        }
    }
}
