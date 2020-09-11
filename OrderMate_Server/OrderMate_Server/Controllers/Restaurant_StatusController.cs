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
    [Route("api/restaurantStatus")]
    [ApiController]
    public class Restaurant_StatusController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Restaurant_StatusController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllRestaurantStatusses()
        {
            try
            {
                var restaurantStatusses = _repository.Restaurant_Status.GetAllRestaurantStatusses();
                _logger.LogInfo($"Returned all restaurantStatusses from db.");

                var restaurantStatussesResult = _mapper.Map<IEnumerable<Restaurant_StatusDto>>(restaurantStatusses);
                return Ok(restaurantStatussesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllRestaurantStatusses action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "Restaurant_StatusById")]
        public IActionResult GetRestaurant_StatusById(int id)
        {
            try
            {
                var restaurantStatus = _repository.Restaurant_Status.GetRestaurantStatusById(id);

                if (restaurantStatus == null)
                {
                    _logger.LogError($"restaurantStatus with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned restaurantStatus with id: {id}");

                    var restaurantStatusResult = _mapper.Map<Restaurant_StatusDto>(restaurantStatus);
                    return Ok(restaurantStatusResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurant_StatusById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetRestaurant_StatusWithDetails(int id)
        {
            try
            {
                var restaurantStatus = _repository.Restaurant_Status.GetRestaurantStatusWithDetails(id);

                if (restaurantStatus == null)
                {
                    _logger.LogError($"restaurantStatus with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"restaurantStatus with details for id: {id}");

                    var restaurantStatusResult = _mapper.Map<Restaurant_StatusDetailsDto>(restaurantStatus);
                    return Ok(restaurantStatusResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurant_StatusWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateRestaurant_Status([FromBody] Restaurant_StatusForCreationDto restaurantStatus)
        {
            try
            {
                if (restaurantStatus == null)
                {
                    _logger.LogError("restaurantStatus object sent from client is null.");
                    return BadRequest("restaurantStatus object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid restaurantStatus object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var restaurantStatusEntity = _mapper.Map<RestaurantStatus>(restaurantStatus);

                _repository.Restaurant_Status.CreateRestaurantStatus(restaurantStatusEntity);
                _repository.Save();

                var createdRestaurant_Status = _mapper.Map<Restaurant_StatusDto>(restaurantStatusEntity);

                return CreatedAtRoute("Restaurant_StatusById", new { id = createdRestaurant_Status.RestaurantStatusId }, createdRestaurant_Status);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateRestaurant_Status action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant_Status(int id, [FromBody] Restaurant_StatusForUpdateDto restaurantStatus)
        {
            try
            {
                if (restaurantStatus == null)
                {
                    _logger.LogError("restaurantStatus object sent from client is null.");
                    return BadRequest("restaurantStatus object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid restaurantStatus object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var restaurantStatusEntity = _repository.Restaurant_Status.GetRestaurantStatusById(id);
                if (restaurantStatusEntity == null)
                {
                    _logger.LogError($"restaurantStatus with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(restaurantStatus, restaurantStatusEntity);

                _repository.Restaurant_Status.UpdateRestaurantStatus(restaurantStatusEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateRestaurant_Status action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant_Status(int id)
        {
            try
            {
                var restaurantStatus = _repository.Restaurant_Status.GetRestaurantStatusById(id);
                if (restaurantStatus == null)
                {
                    _logger.LogError($"restaurantStatus with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Restaurant_Status.DeleteRestaurantStatus(restaurantStatus);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteRestaurant_Status action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
