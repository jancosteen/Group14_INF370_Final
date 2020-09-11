using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contacts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderMate_Server.Controllers
{
    [Route("api/restaurantr")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public RestaurantController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllRestaurants()
        {
            try
            {
                var restaurants = _repository.Restaurant.GetAllRestaurants();
                _logger.LogInfo($"Returned all restaurants from db.");

                var restaurantsResult = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
                return Ok(restaurantsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllRestaurants action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "RestaurantById")]
        public IActionResult GetRestaurantById(int id)
        {
            try
            {
                var restaurant = _repository.Restaurant.GetRestaurantById(id);

                if (restaurant == null)
                {
                    _logger.LogError($"restaurant with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned restaurant with id: {id}");

                    var restaurantResult = _mapper.Map<RestaurantDto>(restaurant);
                    return Ok(restaurantResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurantById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("qrCode/{qrCodeId}", Name = "RestaurantByQrCode")]
        public IActionResult GetRestaurantByQrCode(int qrCodeId)
        {
            try
            {
                var restaurant = _repository.Restaurant.GetRestaurantByQrCode(qrCodeId);

                if (restaurant == null)
                {
                    _logger.LogError($"restaurant with id: {qrCodeId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned restaurant with id: {qrCodeId}");

                    var restaurantResult = _mapper.Map<RestaurantDto>(restaurant);
                    return Ok(restaurantResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurantById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetRestaurantWithDetails(int id)
        {
            try
            {
                var restaurant = _repository.Restaurant.GetRestaurantWithDetails(id);

                if (restaurant == null)
                {
                    _logger.LogError($"restaurant with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"restaurant with details for id: {id}");

                    var restaurantResult = _mapper.Map<RestaurantDetailsDto>(restaurant);
                    return Ok(restaurantResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurantWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateRestaurant([FromBody] RestaurantForCreationDto restaurant)
        {
            try
            {
                if (restaurant == null)
                {
                    _logger.LogError("restaurant object sent from client is null.");
                    return BadRequest("restaurant object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid restaurant object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var restaurantEntity = _mapper.Map<Restaurant>(restaurant);

                _repository.Restaurant.CreateRestaurant(restaurantEntity);
                _repository.Save();

                var createdRestaurant = _mapper.Map<RestaurantDto>(restaurantEntity);

                return CreatedAtRoute("RestaurantById", new { id = createdRestaurant.RestaurantId }, createdRestaurant);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateRestaurant action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant(int id, [FromBody] RestaurantForUpdateDto restaurant)
        {
            try
            {
                if (restaurant == null)
                {
                    _logger.LogError("restaurant object sent from client is null.");
                    return BadRequest("restaurant object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid restaurant object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var restaurantEntity = _repository.Restaurant.GetRestaurantById(id);
                if (restaurantEntity == null)
                {
                    _logger.LogError($"restaurant with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(restaurant, restaurantEntity);

                _repository.Restaurant.UpdateRestaurant(restaurantEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateRestaurant action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            try
            {
                var restaurant = _repository.Restaurant.GetRestaurantById(id);
                if (restaurant == null)
                {
                    _logger.LogError($"restaurant with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Restaurant.DeleteRestaurant(restaurant);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteRestaurant action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
