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
    [Route("api/MenuItemItemType")]
    [ApiController]
    public class MenuItem_ItemTypeController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public MenuItem_ItemTypeController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllMenuItemItemTypes()
        {
            try
            {
                var menuItemTypes = _repository.MenuItem_ItemType.GetAllMenuItemItemTypes();
                _logger.LogInfo($"Returned all menuItemTypes from db.");

                var menuItemTypesResult = _mapper.Map<IEnumerable<MenuItem_ItemTypeDto>>(menuItemTypes);
                return Ok(menuItemTypesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetAllMenuItemItemTypes action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{menuItemTypeId}/{menuItemId}", Name = "MenuItemItemTypeById")]
        public IActionResult GetMenuItemItermTypeById(int menuItemTypeId, int menuItemId)
        {
            try
            {
                var menuItemType = _repository.MenuItem_ItemType.GetMenuItemItemTypeById(menuItemTypeId, menuItemId);
                if (menuItemType == null)
                {
                    _logger.LogError($"menuItemType with menuItemTypeId id: {menuItemTypeId} and menuItemId :{menuItemId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned menuItemType with menuItemTypeId id: {menuItemTypeId} and menuItemId :{menuItemId} from database.");
                    var menuItemTypeResult = _mapper.Map<MenuItem_ItemTypeDto>(menuItemType);
                    return Ok(menuItemTypeResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMenuItemItemTypeById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{menuItemTypeId}/{menuItemId}/detail", Name = "MenuItemItemTypeDetails")]
        public IActionResult GetMenuItemItemTypeDetails(int menuItemTypeId, int menuItemId)
        {
            try
            {
                var menuItemType = _repository.MenuItem_ItemType.GetMenuItemItemTypeWithDetails(menuItemTypeId, menuItemId);
                if (menuItemType == null)
                {
                    _logger.LogError($"menuItemType with menuItemTypeId id: {menuItemTypeId} and menuItemId :{menuItemId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned menuItemType with menuItemTypeId id: {menuItemTypeId} and menuItemId :{menuItemId} from database.");
                    var menuItemTypeResult = _mapper.Map<MenuItem_ItemTypeDetailsDto>(menuItemType);
                    return Ok(menuItemTypeResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMenuItemItemTypeDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateMenuItemItemType([FromBody] MenuItem_ItemTypeForCreationDto menuItemType)
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

                var menuItemTypeEntity = _mapper.Map<ItemTypeMenuMenuItem>(menuItemType);

                _repository.MenuItem_ItemType.CreateMenuItemItemType(menuItemTypeEntity);
                _repository.Save();

                var createdMenuItemType = _mapper.Map<MenuItem_ItemTypeDto>(menuItemTypeEntity);

                return CreatedAtRoute("MenuItemItemTypeDetails", new { menuItemTypeId = createdMenuItemType.MenuItemTypeIdFk, menuItemId = createdMenuItemType.MenuItemIdFk }, createdMenuItemType);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateMenuItemItemType action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{menuItemTypeId}/{menuItemId}")]
        public IActionResult UpdateMenuItemItemType(int menuItemTypeId, int menuItemId, [FromBody] MenuItem_ItemTypeForUpdateDto menuItemType)
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

                var menuItemTypeEntity = _repository.MenuItem_ItemType.GetMenuItemItemTypeById(menuItemTypeId, menuItemId);
                if (menuItemTypeEntity == null)
                {
                    _logger.LogError($"menuItemType with menuItemType: {menuItemType} and menuItemId: {menuItemId}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(menuItemType, menuItemTypeEntity);

                _repository.MenuItem_ItemType.Update(menuItemTypeEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateMenuItemItemType action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
