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
    [Route("api/menuItemPrice")]
    [ApiController]
    public class MenuItem_PriceController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public MenuItem_PriceController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllMenuItemPrices()
        {
            try
            {
                var menuItemPrices = _repository.MenuItem_Price.GetAllMenuItemPrices();
                _logger.LogInfo($"Returned all menuItemPrices from db.");

                var menuItemPricesResult = _mapper.Map<IEnumerable<MenuItem_PriceDto>>(menuItemPrices);
                return Ok(menuItemPricesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetAllMenuItemPrices action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "MenuItemPriceById")]
        public IActionResult GetMenuItemPriceById(int id)
        {
            try
            {
                var menuItemPrice = _repository.MenuItem_Price.GetMenuITemPriceById(id);

                if (menuItemPrice == null)
                {
                    _logger.LogError($"menuItemPrice with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned menuItemPrice with id: {id}");

                    var menuItemPriceResult = _mapper.Map<MenuItem_PriceDto>(menuItemPrice);
                    return Ok(menuItemPriceResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMenuItemPriceById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/menuItem", Name = "MenuItemPriceByMenuItem")]
        public IActionResult GetMenuItemPriceByMenuItem(int id)
        {
            try
            {
                var menuItemPrice = _repository.MenuItem_Price.GetMenuITemPriceByMenuItemId(id);

                if (menuItemPrice == null)
                {
                    _logger.LogError($"menuItemPrice with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned menuItemPrice with id: {id}");

                    var menuItemPriceResult = _mapper.Map<MenuItem_PriceDto>(menuItemPrice);
                    return Ok(menuItemPrice);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMenuItemPriceById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetMenuItemPriceWithDetails(int id)
        {
            try
            {
                var menuItemPrice = _repository.MenuItem_Price.GetMenuItemPriceWithDetails(id);

                if (menuItemPrice == null)
                {
                    _logger.LogError($"menuItemPrice with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"menuItemPrice with details for id: {id}");

                    var menuItemPriceResult = _mapper.Map<MenuItem_PriceDetailsDto>(menuItemPrice);
                    return Ok(menuItemPriceResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMenuItemPriceWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateMenuItemPrice([FromBody] MenuItem_PriceForCreationDto menuItemPrice)
        {
            try
            {
                if (menuItemPrice == null)
                {
                    _logger.LogError("menuItemPrice object sent from client is null.");
                    return BadRequest("menuItemPrice object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid menuItemPrice object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var menuItemPriceEntity = _mapper.Map<MenuItemPrice>(menuItemPrice);

                _repository.MenuItem_Price.CreateMenuItemPrice(menuItemPriceEntity);
                _repository.Save();

                var createdMenuItemPrice = _mapper.Map<MenuItem_PriceDto>(menuItemPriceEntity);

                return CreatedAtRoute("MenuItemPriceById", new { id = createdMenuItemPrice.MenuItemPriceId }, createdMenuItemPrice);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateMenuItemPrice action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMenuItemPrice(int id, [FromBody] MenuItem_PriceForUpdateDto menuItemPrice)
        {
            try
            {
                if (menuItemPrice == null)
                {
                    _logger.LogError("menuItemPrice object sent from client is null.");
                    return BadRequest("menuItemPrice object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid menuItemPrice object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var menuItemPriceEntity = _repository.MenuItem_Price.GetMenuITemPriceById(id);
                if (menuItemPriceEntity == null)
                {
                    _logger.LogError($"menuItemPrice with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(menuItemPrice, menuItemPriceEntity);

                _repository.MenuItem_Price.UpdateMenuItemPrice(menuItemPriceEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateMenuItemPrice action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMenuItemPrice(int id)
        {
            try
            {
                var menuItemPrice = _repository.MenuItem_Price.GetMenuITemPriceById(id);
                if (menuItemPrice == null)
                {
                    _logger.LogError($"menuItemPrice with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.MenuItem_Price.DeleteMenuItemPrice(menuItemPrice);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteMenuItemPrice action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
