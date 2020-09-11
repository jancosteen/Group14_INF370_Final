using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contacts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OrderMate_Server.Controllers
{
    [Route("api/userRole")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private RoleManager<IdentityRole> _roleManager;

        public UserRoleController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult GetAllUserRoles()
        {
            try
            {
                var userRoles = _repository.User_Role.GetAllUserRoles();
                _logger.LogInfo($"Returned all userRoles from db.");

             //   var userRolesResult = _mapper.Map<IEnumerable<UserRole>>(userRoles);
                return Ok(userRoles);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllUserRoles action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "UserRoleById")]
        public IActionResult GetUserRoleById(string id)
        {
            try
            {
                var allergy = _repository.User_Role.GetUserRoleById(id);

                if (allergy == null)
                {
                    _logger.LogError($"allergy with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned allergy with id: {id}");

                   // var allergyResult = _mapper.Map<UserRole>(allergy);
                    return Ok(allergy);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserRoleById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetUserRoleWithDetails(string id)
        {
            try
            {
                var allergy = _repository.User_Role.GetUserRoleWithDetails(id);

                if (allergy == null)
                {
                    _logger.LogError($"allergy with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"allergy with details for id: {id}");

                  //  var allergyResult = _mapper.Map<UserRole>(allergy);
                    return Ok(allergy);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserRoleWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateUserRole(IdentityRole allergy)
        {
            string message = "";
            var roleExists = await _roleManager.RoleExistsAsync(allergy.Name);
            if (!roleExists)
            {
                var role = new IdentityRole();
                role.Name = allergy.Name;
                //role.NormalizedName = allergy.NormalizedName.ToUpper();
            
                
                var result = await _roleManager.CreateAsync(role);

                message = "success";
                return Ok(result);
            }
            else
            {
                message = "Role Already Exists";
                return BadRequest(new { message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserRole(string id, [FromBody] IdentityRole allergy)
        {
            try
            {
                if (allergy == null)
                {
                    _logger.LogError("allergy object sent from client is null.");
                    return BadRequest("allergy object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid allergy object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var allergyEntity = _repository.User_Role.GetUserRoleById(id);
                if (allergyEntity == null)
                {
                    _logger.LogError($"allergy with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

              //  _mapper.Map(allergy, allergyEntity);

                _repository.User_Role.UpdateUserRole(allergy);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateUserRole action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserRole(string id)
        {
            try
            {
                var allergy = _repository.User_Role.GetUserRoleById(id);
                if (allergy == null)
                {
                    _logger.LogError($"allergy with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.User_Role.DeleteUserRole(allergy);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteUserRole action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
