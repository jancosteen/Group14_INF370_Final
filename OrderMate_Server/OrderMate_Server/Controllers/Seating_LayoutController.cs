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
    [Route("api/seatingLayout")]
    [ApiController]
    public class Seating_LayoutController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Seating_LayoutController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllSeatingLayouts()
        {
            try
            {
                var allergies = _repository.Seating_Layout.GetAllSeatingLayouts();
                _logger.LogInfo($"Returned all allergies from db.");

                var allergiesResult = _mapper.Map<IEnumerable<Seating_LayoutDto>>(allergies);
                return Ok(allergiesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllSeatingLayouts action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "Seating_LayoutById")]
        public IActionResult GetSeating_LayoutById(int id)
        {
            try
            {
                var seatingLayout = _repository.Seating_Layout.GetSeatingLayoutById(id);

                if (seatingLayout == null)
                {
                    _logger.LogError($"seatingLayout with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned seatingLayout with id: {id}");

                    var seatingLayoutResult = _mapper.Map<Seating_LayoutDto>(seatingLayout);
                    return Ok(seatingLayoutResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSeating_LayoutById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetSeating_LayoutWithDetails(int id)
        {
            try
            {
                var seatingLayout = _repository.Seating_Layout.GetSeatingLayoutDetails(id);

                if (seatingLayout == null)
                {
                    _logger.LogError($"seatingLayout with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"seatingLayout with details for id: {id}");

                    var seatingLayoutResult = _mapper.Map<Seating_LayoutDetailsDto>(seatingLayout);
                    return Ok(seatingLayoutResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSeating_LayoutWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateSeating_Layout([FromBody] Seating_LayoutForCreationDto seatingLayout)
        {
            try
            {
                if (seatingLayout == null)
                {
                    _logger.LogError("seatingLayout object sent from client is null.");
                    return BadRequest("seatingLayout object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid seatingLayout object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var seatingLayoutEntity = _mapper.Map<SeatingLayout>(seatingLayout);

                _repository.Seating_Layout.CreateSeatingLayout(seatingLayoutEntity);
                _repository.Save();

                var createdSeating_Layout = _mapper.Map<Seating_LayoutDto>(seatingLayoutEntity);

                return CreatedAtRoute("Seating_LayoutById", new { id = createdSeating_Layout.SeatingLayoutId }, createdSeating_Layout);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSeating_Layout action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSeating_Layout(int id, [FromBody] Seating_LayoutForUpdateDto seatingLayout)
        {
            try
            {
                if (seatingLayout == null)
                {
                    _logger.LogError("seatingLayout object sent from client is null.");
                    return BadRequest("seatingLayout object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid seatingLayout object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var seatingLayoutEntity = _repository.Seating_Layout.GetSeatingLayoutById(id);
                if (seatingLayoutEntity == null)
                {
                    _logger.LogError($"seatingLayout with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(seatingLayout, seatingLayoutEntity);

                _repository.Seating_Layout.UpdateSeatingLayout(seatingLayoutEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSeating_Layout action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSeating_Layout(int id)
        {
            try
            {
                var seatingLayout = _repository.Seating_Layout.GetSeatingLayoutById(id);
                if (seatingLayout == null)
                {
                    _logger.LogError($"seatingLayout with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Seating_Layout.DeleteSeatingLayout(seatingLayout);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteSeating_Layout action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
