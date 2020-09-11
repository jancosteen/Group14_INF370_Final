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
    [Route("api/shiftStatus")]
    [ApiController]
    public class ShiftStatusController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ShiftStatusController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllShiftStatusses()
        {
            try
            {
                var shStatus = _repository.Shift_Status.GetAllShiftStatusses();
                _logger.LogInfo($"Returned all shStatus from db.");

                var shStatusResult = _mapper.Map<IEnumerable<ShiftStatusDto>>(shStatus);
                return Ok(shStatusResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllShiftStatusses action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "ShiftStatusById")]
        public IActionResult GetShiftStatusById(int id)
        {
            try
            {
                var shStatus = _repository.Shift_Status.GetShiftStatusById(id);

                if (shStatus == null)
                {
                    _logger.LogError($"shStatus with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned shStatus with id: {id}");

                    var shStatusResult = _mapper.Map<ShiftStatusDto>(shStatus);
                    return Ok(shStatusResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetShiftStatusById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetShiftStatusDetails(int id)
        {
            try
            {
                var shStatus = _repository.Shift_Status.GetShiftStatusDetails(id);

                if (shStatus == null)
                {
                    _logger.LogError($"shStatus with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"shStatus category with details for id: {id}");

                    var shStatusResult = _mapper.Map<ShiftStatusDetailsDto>(shStatus);
                    return Ok(shStatusResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetShiftStatusDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateShiftStatus([FromBody] ShiftStatusForCreationDto shStatus)
        {
            try
            {
                if (shStatus == null)
                {
                    _logger.LogError("shStatus object sent from client is null.");
                    return BadRequest("shStatus object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid shStatus object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var shStatusEntity = _mapper.Map<ShiftStatus>(shStatus);

                _repository.Shift_Status.CreateShiftStatus(shStatusEntity);
                _repository.Save();

                var createdShStatus = _mapper.Map<ShiftStatusDto>(shStatusEntity);

                return CreatedAtRoute("ShiftStatusById", new { id = createdShStatus.ShiftStatusId }, createdShStatus);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateShiftStatus action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShiftStatus(int id, [FromBody] ShiftStatusForUpdateDto shStatus)
        {
            try
            {
                if (shStatus == null)
                {
                    _logger.LogError("shStatus object sent from client is null.");
                    return BadRequest("shStatus object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid shStatus object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var shStatusEntity = _repository.Shift_Status.GetShiftStatusById(id);
                if (shStatusEntity == null)
                {
                    _logger.LogError($"shStatus with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(shStatus, shStatusEntity);

                _repository.Shift_Status.UpdateShiftStatus(shStatusEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateShiftStatus action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShiftStatus(int id)
        {
            try
            {
                var shStatus = _repository.Shift_Status.GetShiftStatusById(id);
                if (shStatus == null)
                {
                    _logger.LogError($"shStatus with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Shift_Status.DeleteShiftStatus(shStatus);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteShiftStatus action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
