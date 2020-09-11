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
    [Route("api/menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public MenuController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllMenus()
        {
            try
            {
                var menus = _repository.Menu.GetAllMenus();
                _logger.LogInfo($"Returned all menus from db.");

                var menusResult = _mapper.Map<IEnumerable<MenuDto>>(menus);
                return Ok(menusResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllMenus action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "MenuById")]
        public IActionResult GetMenuById(int id)
        {
            try
            {
                var menu = _repository.Menu.GetMenuById(id);

                if (menu == null)
                {
                    _logger.LogError($"menu with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned menu with id: {id}");

                    var menuResult = _mapper.Map<MenuDto>(menu);
                    return Ok(menuResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMenuById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetMenuWithDetails(int id)
        {
            try
            {
                var menu = _repository.Menu.GetMenuWithDetails(id);

                if (menu == null)
                {
                    _logger.LogError($"menu with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"menu with details for id: {id}");

                    var menuResult = _mapper.Map<MenuDetailsDto>(menu);
                    return Ok(menuResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMenuWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/res")]
        public IActionResult GetMenuByRestaurant(int id)
        {
            try
            {
                var menu = _repository.Menu.GetMenuByResId(id);

                if (menu == null)
                {
                    _logger.LogError($"menu with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"menu with details for id: {id}");

                    var menuResult = _mapper.Map<MenuDetailsDto>(menu);
                    return Ok(menuResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMenuWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateMenu([FromBody] MenuForCreationDto menu)
        {
            try
            {
                if (menu == null)
                {
                    _logger.LogError("menu object sent from client is null.");
                    return BadRequest("menu object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid menu object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var menuEntity = _mapper.Map<Menu>(menu);

                _repository.Menu.CreateMenu(menuEntity);
                _repository.Save();

                var createdMenu = _mapper.Map<MenuDto>(menuEntity);

                return CreatedAtRoute("MenuById", new { id = createdMenu.MenuId }, createdMenu);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateMenu action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMenu(int id, [FromBody] MenuForUpdateDto menu)
        {
            try
            {
                if (menu == null)
                {
                    _logger.LogError("menu object sent from client is null.");
                    return BadRequest("menu object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid menu object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var menuEntity = _repository.Menu.GetMenuById(id);
                if (menuEntity == null)
                {
                    _logger.LogError($"menu with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(menu, menuEntity);

                _repository.Menu.UpdateMenu(menuEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateMenu action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenu(int id)
        {
            try
            {
                var menu = _repository.Menu.GetMenuById(id);
                if (menu == null)
                {
                    _logger.LogError($"menu with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Menu.DeleteMenu(menu);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteMenu action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
