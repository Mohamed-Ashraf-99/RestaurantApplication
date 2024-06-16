using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler(IRestaurantsRepository _restaurantsRepository, ILogger<UpdateRestaurantCommandHandler> _logger, IMapper _mapper) : IRequestHandler<UpdateRestaurantCommand, bool>
    {
        public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request), "UpdateRestaurantCommand request cannot be null.");
            }

            _logger.LogInformation("Updating restaurant with id: {RestaurantId}", request.Id);

            try
            {
                var restaurant = await _restaurantsRepository.GetRestaurantByIdAsync(request.Id);
                if (restaurant is null)
                {
                    _logger.LogWarning("Restaurant with id: {RestaurantId} not found.", request.Id);
                    return false;
                }
                _mapper.Map(request, restaurant);
                await _restaurantsRepository.SaveChanges();
                _logger.LogInformation("Restaurant with id: {RestaurantId} successfully updated.", request.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the restaurant with id: {RestaurantId}", request.Id);
                return false;
            }
        }
    }
}
