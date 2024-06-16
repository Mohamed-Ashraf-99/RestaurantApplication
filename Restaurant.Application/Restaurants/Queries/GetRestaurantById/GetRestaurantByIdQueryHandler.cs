using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryHandler(IRestaurantsRepository _restaurantsRepository, ILogger<GetRestaurantByIdQueryHandler> _logger, IMapper _mapper) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
        {
            _logger.LogWarning("Invalid restaurant ID: {RestaurantId}", request.Id);
            throw new ArgumentException("Restaurant ID must be greater than zero.", nameof(request.Id));
        }

        _logger.LogInformation("Getting restaurant with ID: {RestaurantId}", request.Id);
        try
        {
            var restaurant = await _restaurantsRepository.GetRestaurantByIdAsync(request.Id);
            if (restaurant is null)
            {
                _logger.LogWarning("Restaurant with ID {RestaurantId} not found.", request.Id);
            }
            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

            return restaurantDto;
        }
        catch (NullReferenceException ex)
        {
            _logger.LogError(ex, "An error occurred while getting the restaurant with ID {RestaurantId}.", request.Id);
            throw new NullReferenceException("There are no restaurant with this id", ex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting the restaurant with ID {RestaurantId}.", request.Id);
            throw new Exception("There are no restaurant with this id", ex);
        }
    }
}
