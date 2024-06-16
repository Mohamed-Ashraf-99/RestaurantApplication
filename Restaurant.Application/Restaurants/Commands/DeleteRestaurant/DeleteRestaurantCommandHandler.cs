using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler(IRestaurantsRepository _restaurantsRepository, ILogger<DeleteRestaurantCommandHandler> _logger, IMapper _mapper)
        :
        IRequestHandler<DeleteRestaurantCommand, bool>
    {
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request), "DeleteRestaurantCommand request cannot be null.");
            }

            _logger.LogInformation("Deleting restaurant with id: {RestaurantId}", request.Id);

            try
            {
                var restaurant = await _restaurantsRepository.GetRestaurantByIdAsync(request.Id);
                if (restaurant == null)
                {
                    _logger.LogWarning("Restaurant with id: {RestaurantId} not found.", request.Id);
                    return false;
                }

                await _restaurantsRepository.Delete(restaurant);
                _logger.LogInformation("Restaurant with id: {RestaurantId} successfully deleted.", request.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the restaurant with id: {RestaurantId}", request.Id);
                return false;
            }
        }


    }
}
