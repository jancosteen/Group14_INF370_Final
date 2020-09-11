using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contacts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderMate_Server.Controllers
{

    [Authorize]
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public EmployeeController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _repository.Employee.GetAllEmployees();
                _logger.LogInfo($"Returned all employees from db.");

                var employeesResult = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
                return Ok(employeesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllEmployees action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "EmployeeById")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = _repository.Employee.GetEmployeeById(id);

                if (employee == null)
                {
                    _logger.LogError($"employee with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned employee with id: {id}");

                    var employeeResult = _mapper.Map<EmployeeDto>(employee);
                    return Ok(employeeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetEmployeeById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetEmployeeDetails(int id)
        {
            try
            {
                var employee = _repository.Employee.GetEmployeeDetails(id);

                if (employee == null)
                {
                    _logger.LogError($"employee with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"employee category with details for id: {id}");

                    var employeeResult = _mapper.Map<EmployeeDetailsDto>(employee);
                    return Ok(employeeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetEmployeeDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeForCreationDto employee)
        {
            try
            {
                if (employee == null)
                {
                    _logger.LogError("employee object sent from client is null.");
                    return BadRequest("employee object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid employee object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var employeeEntity = _mapper.Map<Employee>(employee);

                _repository.Employee.CreateEmployee(employeeEntity);
                _repository.Save();

                var createdEmployee = _mapper.Map<EmployeeDto>(employeeEntity);

                return CreatedAtRoute("EmployeeById", new { id = createdEmployee.EmployeeId }, createdEmployee);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateEmployee action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeForUpdateDto employee)
        {
            try
            {
                if (employee == null)
                {
                    _logger.LogError("employee object sent from client is null.");
                    return BadRequest("employee object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid employee object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var employeeEntity = _repository.Employee.GetEmployeeById(id);
                if (employeeEntity == null)
                {
                    _logger.LogError($"employee with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(employee, employeeEntity);

                _repository.Employee.UpdateEmployee(employeeEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateEmployee action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var employee = _repository.Employee.GetEmployeeById(id);
                if (employee == null)
                {
                    _logger.LogError($"employee with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Employee.DeleteEmployee(employee);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteEmployee action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
