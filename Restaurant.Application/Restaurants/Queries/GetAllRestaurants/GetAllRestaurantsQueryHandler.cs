using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQueryHandler(IRestaurantsRepository _restaurantsRepository, ILogger<GetAllRestaurantsQueryHandler> _logger, IMapper _mapper) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
    {
        public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting all restaurants");
            try
            {
                var restaurants = await _restaurantsRepository.GetRestaurantsAsync();

                var restaurantsDto = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

                return restaurantsDto;
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex, "An error occurred while getting all restaurants.");
                throw new NullReferenceException("Empty", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all restaurants.");
                throw new Exception("Empty", ex);
            }
        }
    }
}
