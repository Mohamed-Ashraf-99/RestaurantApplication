using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(IRestaurantsRepository _restaurantsRepository, ILogger<CreateRestaurantCommandHandler> _logger, IMapper _mapper) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            _logger.LogWarning("CreateRestaurantDto is null.");
            throw new ArgumentNullException(nameof(request), "Restaurant data is required.");
        }

        _logger.LogInformation("Creating a new restaurant with data: {@CreateRestaurantDto}", request);

        try
        {
            var restaurant = _mapper.Map<Restaurant>(request);
            int id = await _restaurantsRepository.Create(restaurant);
            _logger.LogInformation("Restaurant created successfully with ID: {RestaurantId}", id);
            return id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while creating the restaurant with data: {@CreateRestaurantDto}", request);
            throw; // Re-throw the exception to let the caller handle it.
        } 
    }
}
