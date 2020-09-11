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
    [Route("api/resType")]
    [ApiController]
    public class Restaurant_TypeController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Restaurant_TypeController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllRestaurantTypes()
        {
            try
            {
                var restaurantTypes = _repository.Restaurant_Type.GetAllRestaurantTypes();
                _logger.LogInfo($"Returned all restaurantTypes from db.");

                var restaurantTypesResult = _mapper.Map<IEnumerable<Restaurant_TypeDto>>(restaurantTypes);
                return Ok(restaurantTypesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllRestaurantTypes action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "Restaurant_TypeById")]
        public IActionResult GetRestaurant_TypeById(int id)
        {
            try
            {
                var restaurantType = _repository.Restaurant_Type.GetRestaurantTypeById(id);

                if (restaurantType == null)
                {
                    _logger.LogError($"restaurantType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned restaurantType with id: {id}");

                    var restaurantTypeResult = _mapper.Map<Restaurant_TypeDto>(restaurantType);
                    return Ok(restaurantTypeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurant_TypeById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetRestaurant_TypeWithDetails(int id)
        {
            try
            {
                var restaurantType = _repository.Restaurant_Type.GetRestaurantTypeWithDetails(id);

                if (restaurantType == null)
                {
                    _logger.LogError($"restaurantType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"restaurantType with details for id: {id}");

                    var restaurantTypeResult = _mapper.Map<Restaurant_TypeDetailsDto>(restaurantType);
                    return Ok(restaurantTypeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurant_TypeWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateRestaurant_Type([FromBody] Restaurant_TypeForCreationDto restaurantType)
        {
            try
            {
                if (restaurantType == null)
                {
                    _logger.LogError("restaurantType object sent from client is null.");
                    return BadRequest("restaurantType object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid restaurantType object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var restaurantTypeEntity = _mapper.Map<RestaurantType>(restaurantType);

                _repository.Restaurant_Type.CreateRestaurantType(restaurantTypeEntity);
                _repository.Save();

                var createdRestaurant_Type = _mapper.Map<Restaurant_TypeDto>(restaurantTypeEntity);

                return CreatedAtRoute("Restaurant_TypeById", new { id = createdRestaurant_Type.RestaurantTypeId }, createdRestaurant_Type);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateRestaurant_Type action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant_Type(int id, [FromBody] Restaurant_TypeForUpdateDto restaurantType)
        {
            try
            {
                if (restaurantType == null)
                {
                    _logger.LogError("restaurantType object sent from client is null.");
                    return BadRequest("restaurantType object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid restaurantType object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var restaurantTypeEntity = _repository.Restaurant_Type.GetRestaurantTypeById(id);
                if (restaurantTypeEntity == null)
                {
                    _logger.LogError($"restaurantType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(restaurantType, restaurantTypeEntity);

                _repository.Restaurant_Type.UpdateRestaurantType(restaurantTypeEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateRestaurant_Type action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant_Type(int id)
        {
            try
            {
                var restaurantType = _repository.Restaurant_Type.GetRestaurantTypeById(id);
                if (restaurantType == null)
                {
                    _logger.LogError($"restaurantType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Restaurant_Type.DeleteRestaurantType(restaurantType);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteRestaurant_Type action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
