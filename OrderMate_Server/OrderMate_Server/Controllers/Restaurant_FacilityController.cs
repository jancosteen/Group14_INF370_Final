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
    [Route("api/restaurantFacility")]
    [ApiController]
    public class Restaurant_FacilityController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Restaurant_FacilityController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllRestaurantFacilities()
        {
            try
            {
                var restaurantFacilities = _repository.Restaurant_Facility.GetAllRestaurantFacilitys();
                _logger.LogInfo($"Returned all restaurantFacilities from db.");

                var restaurantFacilitiesResult = _mapper.Map<IEnumerable<Restaurant_FacilityDto>>(restaurantFacilities);
                return Ok(restaurantFacilitiesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllRestaurantFacilities action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "Restaurant_FacilityById")]
        public IActionResult GetRestaurant_FacilityById(int id)
        {
            try
            {
                var restaurantFacility = _repository.Restaurant_Facility.GetRestaurantFacilityById(id);

                if (restaurantFacility == null)
                {
                    _logger.LogError($"restaurantFacility with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned restaurantFacility with id: {id}");

                    var restaurantFacilityResult = _mapper.Map<Restaurant_FacilityDto>(restaurantFacility);
                    return Ok(restaurantFacilityResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurant_FacilityById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetRestaurant_FacilityWithDetails(int id)
        {
            try
            {
                var restaurantFacility = _repository.Restaurant_Facility.GetRestaurantFacilityWithDetails(id);

                if (restaurantFacility == null)
                {
                    _logger.LogError($"restaurantFacility with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"restaurantFacility with details for id: {id}");

                    var restaurantFacilityResult = _mapper.Map<Restaurant_FacilityDetailsDto>(restaurantFacility);
                    return Ok(restaurantFacilityResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurant_FacilityWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateRestaurant_Facility([FromBody] Restaurant_FacilityForCreationDto restaurantFacility)
        {
            try
            {
                if (restaurantFacility == null)
                {
                    _logger.LogError("restaurantFacility object sent from client is null.");
                    return BadRequest("restaurantFacility object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid restaurantFacility object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var restaurantFacilityEntity = _mapper.Map<RestaurantFacility>(restaurantFacility);

                _repository.Restaurant_Facility.CreateRestaurantFacility(restaurantFacilityEntity);
                _repository.Save();

                var createdRestaurant_Facility = _mapper.Map<Restaurant_FacilityDto>(restaurantFacilityEntity);

                return CreatedAtRoute("Restaurant_FacilityById", new { id = createdRestaurant_Facility.RestaurantFacilityId }, createdRestaurant_Facility);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateRestaurant_Facility action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant_Facility(int id, [FromBody] Restaurant_FacilityForUpdateDto restaurantFacility)
        {
            try
            {
                if (restaurantFacility == null)
                {
                    _logger.LogError("restaurantFacility object sent from client is null.");
                    return BadRequest("restaurantFacility object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid restaurantFacility object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var restaurantFacilityEntity = _repository.Restaurant_Facility.GetRestaurantFacilityById(id);
                if (restaurantFacilityEntity == null)
                {
                    _logger.LogError($"restaurantFacility with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(restaurantFacility, restaurantFacilityEntity);

                _repository.Restaurant_Facility.UpdateRestaurantfacility(restaurantFacilityEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateRestaurant_Facility action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant_Facility(int id)
        {
            try
            {
                var restaurantFacility = _repository.Restaurant_Facility.GetRestaurantFacilityById(id);
                if (restaurantFacility == null)
                {
                    _logger.LogError($"restaurantFacility with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Restaurant_Facility.DeleteRestaurantFacility(restaurantFacility);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteRestaurant_Facility action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
