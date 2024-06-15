using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Entities;

namespace Restaurants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController(IRestaurantsServices _restaurantsServices) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await _restaurantsServices.GetAllRestaurants();
            if (restaurants is not null)
                return Ok(restaurants);

            return BadRequest();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var restaurant = await _restaurantsServices.GetRestaurantById(id);
            if (restaurant is not null)
                return Ok(restaurant);

            return BadRequest();
        }
    }
}
