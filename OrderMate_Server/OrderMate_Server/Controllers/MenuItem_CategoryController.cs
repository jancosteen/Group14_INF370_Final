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
    [Route("api/menuItemCategory")]
    [ApiController]
    public class MenuItem_CategoryController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public MenuItem_CategoryController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllMenuItemCategories()
        {
            try
            {
                var menuItemCats = _repository.MenuItem_Category.GetAllMenuItemCategories();
                _logger.LogInfo($"Returned all menuItemCats from db.");

                var menuItemCatsResult = _mapper.Map<IEnumerable<MenuItemCategoryDto>>(menuItemCats);
                return Ok(menuItemCatsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetAllMenuItemCategories action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "MenuItemCategoryById")]
        public IActionResult GetMenuItemCategoryById(int id)
        {
            try
            {
                var menuItemCat = _repository.MenuItem_Category.GetMenuITemCategoryById(id);

                if (menuItemCat == null)
                {
                    _logger.LogError($"menuItemCat with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned menuItemCat with id: {id}");

                    var menuItemCatResult = _mapper.Map<MenuItemCategoryDto>(menuItemCat);
                    return Ok(menuItemCatResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMenuItemCategoryById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetMenuItemaCategoryWithDetails(int id)
        {
            try
            {
                var menuItemCat = _repository.MenuItem_Category.GetMenuItemcateegoryWithDetails(id);

                if (menuItemCat == null)
                {
                    _logger.LogError($"menuItemCat with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"menuItemCat with details for id: {id}");

                    var menuItemCatResult = _mapper.Map<MenuItemCategoryDetailsDto>(menuItemCat);
                    return Ok(menuItemCatResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMenuItemCategoryWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateMenuItemCategory([FromBody] MenuItemCategoryForCreationDto menuItemCat)
        {
            try
            {
                if (menuItemCat == null)
                {
                    _logger.LogError("menuItemCat object sent from client is null.");
                    return BadRequest("menuItemCat object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid menuItemCat object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var menuItemCatEntity = _mapper.Map<MenuItemCategory>(menuItemCat);

                _repository.MenuItem_Category.CreateMenuItemCategory(menuItemCatEntity);
                _repository.Save();

                var createdMenuItemCat = _mapper.Map<MenuItemCategoryDto>(menuItemCatEntity);

                return CreatedAtRoute("MenuITemCategoryById", new { id = createdMenuItemCat.MenuItemCategoryId }, createdMenuItemCat);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateMenuItemCategory action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMenuItemCategory(int id, [FromBody] MenuItemCategoryForUpdateDto menuItemCat)
        {
            try
            {
                if (menuItemCat == null)
                {
                    _logger.LogError("menuItemCat object sent from client is null.");
                    return BadRequest("menuItemCat object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid menuItemCat object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var menuItemCatEntity = _repository.MenuItem_Category.GetMenuITemCategoryById(id);
                if (menuItemCatEntity == null)
                {
                    _logger.LogError($"menuItemCat with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(menuItemCat, menuItemCatEntity);

                _repository.MenuItem_Category.UpdateMenuItemCategory(menuItemCatEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateMenuItemCategory action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuItemCategory(int id)
        {
            try
            {
                var menuItemCat = _repository.MenuItem_Category.GetMenuITemCategoryById(id);
                if (menuItemCat == null)
                {
                    _logger.LogError($"menuItemCat with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.MenuItem_Category.DeleteMenuItemCategory(menuItemCat);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteMenuItemCategory action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
