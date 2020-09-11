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
    [Route("api/menuItem")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public MenuItemController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllMenuItems()
        {
            try
            {
                var MenuItems = _repository.MenuItem.GetAllMenuItems();
                _logger.LogInfo($"Returned all MenuItems from db.");

                var MenuItemsResult = _mapper.Map<IEnumerable<MenuItemDto>>(MenuItems);
                return Ok(MenuItemsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllMenuItems action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "MenuItemById")]
        public IActionResult GetMenuItemById(int id)
        {
            try
            {
                var MenuItem = _repository.MenuItem.GetMenuITemById(id);

                if (MenuItem == null)
                {
                    _logger.LogError($"MenuItem with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned MenuItem with id: {id}");

                    var MenuItemResult = _mapper.Map<MenuItemDto>(MenuItem);
                    return Ok(MenuItemResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMenuItemById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetMenuItemWithDetails(int id)
        {
            try
            {
                var MenuItem = _repository.MenuItem.GetMenuItemWithDetails(id);

                if (MenuItem == null)
                {
                    _logger.LogError($"MenuItem with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"MenuItem with details for id: {id}");

                    var MenuItemResult = _mapper.Map<MenuItemDetailsDto>(MenuItem);
                    return Ok(MenuItemResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMenuItemWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateMenuItem([FromBody] MenuItemForCreationDto menuItem)
        {
            try
            {
                if (menuItem == null)
                {
                    _logger.LogError("MenuItem object sent from client is null.");
                    return BadRequest("MenuItem object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid MenuItem object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var menuItemEntity = _mapper.Map<MenuItem>(menuItem);

                _repository.MenuItem.CreateMenuItem(menuItemEntity);
                _repository.Save();

                var createdMenuItem = _mapper.Map<MenuItemDto>(menuItemEntity);

                return CreatedAtRoute("MenuItemById", new { id = createdMenuItem.MenuItemId }, createdMenuItem);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateMenuItem action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMenuItem(int id, [FromBody] MenuItemForUpdateDto MenuItem)
        {
            try
            {
                if (MenuItem == null)
                {
                    _logger.LogError("MenuItem object sent from client is null.");
                    return BadRequest("MenuItem object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid MenuItem object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var MenuItemEntity = _repository.MenuItem.GetMenuITemById(id);
                if (MenuItemEntity == null)
                {
                    _logger.LogError($"MenuItem with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(MenuItem, MenuItemEntity);

                _repository.MenuItem.UpdateMenuItem(MenuItemEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateMenuItem action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuItem(int id)
        {
            try
            {
                var MenuItem = _repository.MenuItem.GetMenuITemById(id);
                if (MenuItem == null)
                {
                    _logger.LogError($"MenuItem with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.MenuItem.DeleteMenuItem(MenuItem);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteMenuItem action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
