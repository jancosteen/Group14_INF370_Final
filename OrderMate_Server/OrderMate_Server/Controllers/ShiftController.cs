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
    [Route("api/shift")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ShiftController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllShifts()
        {
            try
            {
                var shifts = _repository.Shift.GetAllShifts();
                _logger.LogInfo($"Returned all shifts from db.");

                var shiftsResult = _mapper.Map<IEnumerable<ShiftDto>>(shifts);
                return Ok(shiftsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllShifts action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "ShiftById")]
        public IActionResult GetShiftById(int id)
        {
            try
            {
                var shifts = _repository.Shift.GetShiftById(id);

                if (shifts == null)
                {
                    _logger.LogError($"shifts with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned shifts with id: {id}");

                    var shiftsResult = _mapper.Map<ShiftDto>(shifts);
                    return Ok(shiftsResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetShiftById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetShiftDetails(int id)
        {
            try
            {
                var shifts = _repository.Shift.GetShiftDetails(id);

                if (shifts == null)
                {
                    _logger.LogError($"shifts with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"shifts category with details for id: {id}");

                    var shiftsResult = _mapper.Map<ShiftDetailsDto>(shifts);
                    return Ok(shiftsResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetShiftDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateShift([FromBody] ShiftForCreationDto shifts)
        {
            try
            {
                if (shifts == null)
                {
                    _logger.LogError("shifts object sent from client is null.");
                    return BadRequest("shifts object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid shifts object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var shiftEntity = _mapper.Map<Shift>(shifts);

                _repository.Shift.CreateShift(shiftEntity);
                _repository.Save();

                var createdShiftStatus = _mapper.Map<ShiftDto>(shiftEntity);

                return CreatedAtRoute("ShiftById", new { id = createdShiftStatus.ShiftId }, createdShiftStatus);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateShift action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateShift(int id, [FromBody] ShiftForUpdateDto shift)
        {
            try
            {
                if (shift == null)
                {
                    _logger.LogError("shift object sent from client is null.");
                    return BadRequest("shift object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid shift object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var shiftEntity = _repository.Shift.GetShiftById(id);
                if (shiftEntity == null)
                {
                    _logger.LogError($"shift with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(shift, shiftEntity);

                _repository.Shift.UpdateShift(shiftEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateShift action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShift(int id)
        {
            try
            {
                var shift = _repository.Shift.GetShiftById(id);
                if (shift == null)
                {
                    _logger.LogError($"shift with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Shift.DeleteShift(shift);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteShift action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
