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
    [Route("api/empShift")]
    [ApiController]
    public class EmployeeShiftController : ControllerBase
    {
        //STEPS IN COMMENTS

        //1st: Inject logger and repo service in constructor: public SupplierController(ILoggerManager logger, IRepositoryWrapper repository)
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public EmployeeShiftController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        //2nd Map to a GET function
        //IActionResult - Supports variety of methods AND status codes
        [HttpGet]
        public IActionResult GetAllEmpShifts()
        {
            try
            {
                var empShifts = _repository.Employee_Shift.GetAllEmployeeShifts();
                _logger.LogInfo($"Returned all empShifts records from database");

                var empShiftsResult = _mapper.Map<IEnumerable<EmployeeShiftDto>>(empShifts);

                return Ok(empShiftsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllEmpShifts() action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{employeeId}/{shiftId}", Name = "EmployeeShiftById")]
        public IActionResult GetEmployeeShiftById(int employeeId, int shiftId)
        {
            try
            {
                var empShift = _repository.Employee_Shift.GetEmShiftById(employeeId, shiftId);
                if (empShift == null)
                {
                    _logger.LogError($"empShifts with employeeId id: {employeeId} and shiftId :{shiftId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned empShift with employee id: {employeeId} and shiftId :{shiftId} from database.");
                    var empShiftResult = _mapper.Map<EmployeeShiftDto>(empShift);
                    return Ok(empShiftResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetEmployeeShiftById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{employeeId}/{shiftId}/detail", Name = "EmployeeShiftDetails")]
        public IActionResult GetEmployeeShiftDetails(int employeeId, int shiftId)
        {
            try
            {
                var empShift = _repository.Employee_Shift.GetEmShiftDetails(employeeId, shiftId);
                if (empShift == null)
                {
                    _logger.LogError($"empShift with employeeId id: {employeeId} and shiftId :{shiftId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned empShift with employeeId id: {employeeId} and shiftId :{shiftId} from database.");
                    var empShiftResult = _mapper.Map<EmployeeShiftDetailsDto>(empShift);
                    return Ok(empShiftResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetEmployeeShiftDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateEmployeeShift([FromBody] EmployeeShiftForCreationDto empShift)
        {
            try
            {
                if (empShift == null)
                {
                    _logger.LogError("empShift object sent from client is null.");
                    return BadRequest("empShift object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid empShift object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var empShiftEntity = _mapper.Map<EmployeeShift>(empShift);

                _repository.Employee_Shift.CreateEmShift(empShiftEntity);
                _repository.Save();

                var createdEmpShift = _mapper.Map<EmployeeShiftDto>(empShiftEntity);

                return CreatedAtRoute("EmployeeShiftDetails", new { employeeId = createdEmpShift.EmployeeIdFk, shiftId = createdEmpShift.ShiftIdFk }, createdEmpShift);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateEmployeeShift action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{employeeId}/{shiftId}")]
        public IActionResult UpdateProdStockTake(int employeeId, int shiftId, [FromBody] EmployeeShiftForUpdateDto empShift)
        {
            try
            {
                if (empShift == null)
                {
                    _logger.LogError("empShift object sent from client is null.");
                    return BadRequest("empShift object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid empShift object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var empShiftEntity = _repository.Employee_Shift.GetEmShiftById(employeeId, shiftId);
                if (empShiftEntity == null)
                {
                    _logger.LogError($"empShift with employeeId: {employeeId} and shiftId: {shiftId}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(empShift, empShiftEntity);

                _repository.Employee_Shift.UpdateEmShift(empShiftEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateEmployeeShift action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
