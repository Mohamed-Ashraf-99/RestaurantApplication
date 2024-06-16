using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;
using Restaurants.Domain.Entities;

namespace Restaurants.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController(IMediator _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await _mediator.Send(new GetAllRestaurantsQuery());
            if (restaurants is not null)
                return Ok(restaurants);

            return BadRequest();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var restaurant = await _mediator.Send(new GetRestaurantByIdQuery(id));


            if (restaurant is not null)
                return Ok(restaurant);

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRestaurantCommand createRestaurantCommand)
        {
            if (createRestaurantCommand is null)
                return BadRequest("Restaurant data is required.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                int id = await _mediator.Send(createRestaurantCommand);
                return CreatedAtAction(nameof(Get), new { id }, null);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the restaurant.");
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]  int id)
        {
            var isDeleted = await _mediator.Send(new DeleteRestaurantCommand(id));

            if (isDeleted)
                return NoContent();

            return NotFound();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateRestaurantCommand updateRestaurantCommand)
        {
            updateRestaurantCommand.Id = id;
            var isUpdated = await _mediator.Send(updateRestaurantCommand);

            if(isUpdated)
                return NoContent();

            return NotFound();
        }

    }
}
