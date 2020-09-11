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
    [Route("api/restImage")]
    [ApiController]
    public class Restaurant_ImageController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Restaurant_ImageController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllRestaurantImages()
        {
            try
            {
                var restaurantImages = _repository.Restaurant_Image.GetAllRestaurantImages();
                _logger.LogInfo($"Returned all restaurantImages from db.");

                var restaurantImagesResult = _mapper.Map<IEnumerable<Restaurant_ImageDto>>(restaurantImages);
                return Ok(restaurantImagesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllRestaurantImages action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "Restaurant_ImageById")]
        public IActionResult GetRestaurant_ImageById(int id)
        {
            try
            {
                var restaurantImage = _repository.Restaurant_Image.GetRestaurantImageById(id);

                if (restaurantImage == null)
                {
                    _logger.LogError($"restaurantImage with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned restaurantImage with id: {id}");

                    var restaurantImageResult = _mapper.Map<Restaurant_ImageDto>(restaurantImage);
                    return Ok(restaurantImageResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurant_ImageById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetRestaurant_ImageWithDetails(int id)
        {
            try
            {
                var restaurantImage = _repository.Restaurant_Image.GetRestaurantImageWithDetails(id);

                if (restaurantImage == null)
                {
                    _logger.LogError($"restaurantImage with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"restaurantImage with details for id: {id}");

                    var restaurantImageResult = _mapper.Map<Restaurant_ImageDetailsDto>(restaurantImage);
                    return Ok(restaurantImageResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurant_ImageWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateRestaurant_Image([FromBody] Restaurant_ImageForCreationDto restaurantImage)
        {
            try
            {
                if (restaurantImage == null)
                {
                    _logger.LogError("restaurantImage object sent from client is null.");
                    return BadRequest("restaurantImage object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid restaurantImage object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var restaurantImageEntity = _mapper.Map<RestaurantImage>(restaurantImage);

                _repository.Restaurant_Image.CreateRestaurantImage(restaurantImageEntity);
                _repository.Save();

                var createdRestaurant_Image = _mapper.Map<Restaurant_ImageDto>(restaurantImageEntity);

                return CreatedAtRoute("Restaurant_ImageById", new { id = createdRestaurant_Image.RestaurantImageId }, createdRestaurant_Image);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateRestaurant_Image action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRestaurant_Image(int id, [FromBody] Restaurant_ImageForUpdateDto restaurantImage)
        {
            try
            {
                if (restaurantImage == null)
                {
                    _logger.LogError("restaurantImage object sent from client is null.");
                    return BadRequest("restaurantImage object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid restaurantImage object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var restaurantImageEntity = _repository.Restaurant_Image.GetRestaurantImageById(id);
                if (restaurantImageEntity == null)
                {
                    _logger.LogError($"restaurantImage with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(restaurantImage, restaurantImageEntity);

                _repository.Restaurant_Image.UpdateRestaurantImage(restaurantImageEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateRestaurant_Image action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant_Image(int id)
        {
            try
            {
                var restaurantImage = _repository.Restaurant_Image.GetRestaurantImageById(id);
                if (restaurantImage == null)
                {
                    _logger.LogError($"restaurantImage with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Restaurant_Image.DeleteRestaurantImage(restaurantImage);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteRestaurant_Image action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
