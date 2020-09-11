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
    [Route("api/starRating")]
    [ApiController]
    public class Star_RatingController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Star_RatingController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllStarRatings()
        {
            try
            {
                var starRatings = _repository.Star_Rating.GetAllStarRatings();
                _logger.LogInfo($"Returned all starRatings from db.");

                var starRatingsResult = _mapper.Map<IEnumerable<Star_RatingDto>>(starRatings);
                return Ok(starRatingsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllStarRatings action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "Star_RatingById")]
        public IActionResult GetStar_RatingById(int id)
        {
            try
            {
                var starRating = _repository.Star_Rating.GetStarRatingById(id);

                if (starRating == null)
                {
                    _logger.LogError($"starRating with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned starRating with id: {id}");

                    var starRatingResult = _mapper.Map<Star_RatingDto>(starRating);
                    return Ok(starRatingResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetStar_RatingById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetStar_RatingWithDetails(int id)
        {
            try
            {
                var starRating = _repository.Star_Rating.GetStarRatingWithDetails(id);

                if (starRating == null)
                {
                    _logger.LogError($"starRating with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"starRating with details for id: {id}");

                    var starRatingResult = _mapper.Map<Star_RatingDetailsDto>(starRating);
                    return Ok(starRatingResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetStar_RatingWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateStar_Rating([FromBody] Star_RatingForCreationDto starRating)
        {
            try
            {
                if (starRating == null)
                {
                    _logger.LogError("starRating object sent from client is null.");
                    return BadRequest("starRating object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid starRating object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var starRatingEntity = _mapper.Map<StarRating>(starRating);

                _repository.Star_Rating.CreateStarRating(starRatingEntity);
                _repository.Save();

                var createdStar_Rating = _mapper.Map<Star_RatingDto>(starRatingEntity);

                return CreatedAtRoute("Star_RatingById", new { id = createdStar_Rating.StarRatingId }, createdStar_Rating);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateStar_Rating action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStar_Rating(int id, [FromBody] Star_RatingForUpdateDto starRating)
        {
            try
            {
                if (starRating == null)
                {
                    _logger.LogError("starRating object sent from client is null.");
                    return BadRequest("starRating object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid starRating object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var starRatingEntity = _repository.Star_Rating.GetStarRatingById(id);
                if (starRatingEntity == null)
                {
                    _logger.LogError($"starRating with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(starRating, starRatingEntity);

                _repository.Star_Rating.UpdateStarRating(starRatingEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateStar_Rating action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStar_Rating(int id)
        {
            try
            {
                var starRating = _repository.Star_Rating.GetStarRatingById(id);
                if (starRating == null)
                {
                    _logger.LogError($"starRating with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Star_Rating.DeleteStarRating(starRating);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteStar_Rating action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
