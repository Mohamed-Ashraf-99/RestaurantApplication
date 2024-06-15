

using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants
{
    public class RestaurantsServices(IRestaurantsRepository _restaurantsRepository, ILogger<RestaurantsServices> _logger) : IRestaurantsServices
    {
        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            _logger.LogInformation("Getting all restaurants");
            try
            {
                var restaurants = await _restaurantsRepository.GetRestaurantsAsync();

                var restaurantsDto = restaurants.Select(RestaurantDto.FromEntity);
               
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

        public async Task<RestaurantDto> GetRestaurantById(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Invalid restaurant ID: {RestaurantId}", id);
                throw new ArgumentException("Restaurant ID must be greater than zero.", nameof(id));
            }

            _logger.LogInformation("Getting restaurant with ID: {RestaurantId}", id);
            try
            {
                var restaurant = await _restaurantsRepository.GetRestaurantByIdAsync(id);
                if (restaurant is null)
                {
                    _logger.LogWarning("Restaurant with ID {RestaurantId} not found.", id);
                }
                var restaurantDto = RestaurantDto.FromEntity(restaurant);
        
                return restaurantDto;
            }
            catch (NullReferenceException ex)
            {
                _logger.LogError(ex, "An error occurred while getting the restaurant with ID {RestaurantId}.", id);
                throw new NullReferenceException("There are no restaurant with this id", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the restaurant with ID {RestaurantId}.", id);
                throw new Exception("There are no restaurant with this id", ex);
            }
        }
    }
}
