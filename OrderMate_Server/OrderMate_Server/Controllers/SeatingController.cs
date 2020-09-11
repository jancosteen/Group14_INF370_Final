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
    [Route("api/seating")]
    [ApiController]
    public class SeatingController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public SeatingController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllSeatings()
        {
            try
            {
                var seatings = _repository.Seating.GetAllSeatings();
                _logger.LogInfo($"Returned all seatings from db.");

                var seatingsResult = _mapper.Map<IEnumerable<SeatingDto>>(seatings);
                return Ok(seatingsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllSeatings action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "SeatingById")]
        public IActionResult GetSeatingById(int id)
        {
            try
            {
                var seating = _repository.Seating.GetSeatingById(id);

                if (seating == null)
                {
                    _logger.LogError($"seating with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned seating with id: {id}");

                    var seatingResult = _mapper.Map<SeatingDto>(seating);
                    return Ok(seatingResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSeatingById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetSeatingWithDetails(int id)
        {
            try
            {
                var seating = _repository.Seating.GetSeatingWithDetails(id);

                if (seating == null)
                {
                    _logger.LogError($"seating with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"seating with details for id: {id}");

                    var seatingResult = _mapper.Map<SeatingDetailsDto>(seating);
                    return Ok(seatingResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSeatingWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateSeating([FromBody] SeatingForCreationDto seating)
        {
            try
            {
                if (seating == null)
                {
                    _logger.LogError("seating object sent from client is null.");
                    return BadRequest("seating object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid seating object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var seatingEntity = _mapper.Map<Seating>(seating);

                _repository.Seating.CreateSeating(seatingEntity);
                _repository.Save();

                var createdSeating = _mapper.Map<SeatingDto>(seatingEntity);

                return CreatedAtRoute("SeatingById", new { id = createdSeating.SeatingId }, createdSeating);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSeating action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSeating(int id, [FromBody] SeatingForUpdateDto seating)
        {
            try
            {
                if (seating == null)
                {
                    _logger.LogError("seating object sent from client is null.");
                    return BadRequest("seating object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid seating object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var seatingEntity = _repository.Seating.GetSeatingById(id);
                if (seatingEntity == null)
                {
                    _logger.LogError($"seating with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(seating, seatingEntity);

                _repository.Seating.UpdateSeating(seatingEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSeating action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeating(int id)
        {
            try
            {
                var seating = _repository.Seating.GetSeatingById(id);
                if (seating == null)
                {
                    _logger.LogError($"seating with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Seating.DeleteSeating(seating);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteSeating action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
