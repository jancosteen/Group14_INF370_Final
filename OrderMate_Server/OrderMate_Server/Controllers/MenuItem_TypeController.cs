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
    [Route("api/menuItemType")]
    [ApiController]
    public class MenuItem_TypeController : ControllerBase
    {
        //STEPS IN COMMENTS

        //1st: Inject logger and repo service in constructor: public SupplierController(ILoggerManager logger, IRepositoryWrapper repository)
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public MenuItem_TypeController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        //2nd Map to a GET function
        //IActionResult - Supports variety of methods AND status codes
        [HttpGet]
        public IActionResult GetAllMenuItemTypes()
        {
            try
            {
                var menuItemTypes = _repository.MenuItem_Type.GetAllMenuItemTypes();
                _logger.LogInfo($"Returned all menuItemTypes from db.");

                var menuItemTypesResult = _mapper.Map<IEnumerable<MenuItemTypeDto>>(menuItemTypes);
                return Ok(menuItemTypesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetAllMenuItemTypes action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "MenuItemTypeById")]
        public IActionResult GetmenuItemTypeegoryById(int id)
        {
            try
            {
                var menuItemType = _repository.MenuItem_Type.GetMenuITemTypeById(id);

                if (menuItemType == null)
                {
                    _logger.LogError($"menuItemType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned menuItemType with id: {id}");

                    var menuItemTypeResult = _mapper.Map<MenuItemTypeDto>(menuItemType);
                    return Ok(menuItemTypeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetmenuItemTypById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetMenuItemTypeWithDetails(int id)
        {
            try
            {
                var menuItemType = _repository.MenuItem_Type.GetMenuItemTypeWithDetails(id);

                if (menuItemType == null)
                {
                    _logger.LogError($"menuItemType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"menuItemType with details for id: {id}");

                    var menuItemTypeResult = _mapper.Map<MenuItemTypeDetailsDto>(menuItemType);
                    return Ok(menuItemTypeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetmenuItemTypeWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreatemenuItemType([FromBody] MenuItemTypeForCreationDto menuItemType)
        {
            try
            {
                if (menuItemType == null)
                {
                    _logger.LogError("menuItemType object sent from client is null.");
                    return BadRequest("menuItemType object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid menuItemType object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var menuItemTypeEntity = _mapper.Map<MenuItemType>(menuItemType);

                _repository.MenuItem_Type.CreateMenuItemType(menuItemTypeEntity);
                _repository.Save();

                var createdmenuItemType = _mapper.Map<MenuItemTypeDto>(menuItemTypeEntity);

                return CreatedAtRoute("menuItemTypeegoryById", new { id = createdmenuItemType.MenuItemTypeId }, createdmenuItemType);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreatemenuItemTypeegory action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatemenuItemTypeegory(int id, [FromBody] MenuItemTypeForUpdateDto menuItemType)
        {
            try
            {
                if (menuItemType == null)
                {
                    _logger.LogError("menuItemType object sent from client is null.");
                    return BadRequest("menuItemType object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid menuItemType object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var menuItemTypeEntity = _repository.MenuItem_Type.GetMenuITemTypeById(id);
                if (menuItemTypeEntity == null)
                {
                    _logger.LogError($"menuItemType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(menuItemType, menuItemTypeEntity);

                _repository.MenuItem_Type.UpdateMenuItemtype(menuItemTypeEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdatemenuItemTypeegory action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletemenuItemTypeegory(int id)
        {
            try
            {
                var menuItemType = _repository.MenuItem_Type.GetMenuITemTypeById(id);
                if (menuItemType == null)
                {
                    _logger.LogError($"menuItemType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.MenuItem_Type.DeleteMenuItemType(menuItemType);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeletemenuItemTypeegory action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
