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
    [Route("api/menuItemSpecial")]
    [ApiController]
    public class MenuItem_SpecialController : ControllerBase
    {
        //STEPS IN COMMENTS

        //1st: Inject logger and repo service in constructor: public SupplierController(ILoggerManager logger, IRepositoryWrapper repository)
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public MenuItem_SpecialController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        //2nd Map to a GET function
        //IActionResult - Supports variety of methods AND status codes
        [HttpGet]
        public IActionResult GetAllmenuItemSpecialss()
        {
            try
            {
                var menuItemSpecials = _repository.MenuItem_Special.GetAllMenuItemSpecials();
                _logger.LogInfo($"Returned all menuItemSpecials records from database");

                var menuItemSpecialsResult = _mapper.Map<IEnumerable<MenuItem_SpecialDto>>(menuItemSpecials);

                return Ok(menuItemSpecialsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllmenuItemSpecials() action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{specialId}/{menuItemId}", Name = "menuItemSpecialById")]
        public IActionResult GetmenuItemSpecialById(int specialId, int menuItemId)
        {
            try
            {
                var menuItemSpecial = _repository.MenuItem_Special.GetMenuItemSpecialById(specialId, menuItemId);
                if (menuItemSpecial == null)
                {
                    _logger.LogError($"menuItemSpecial with specialId id: {specialId} and menuItemId :{menuItemId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned menuItemSpecial with specialId id: {specialId} and menuItemId :{menuItemId} from database.");
                    var menuItemSpecialResult = _mapper.Map<MenuItem_SpecialDto>(menuItemSpecial);
                    return Ok(menuItemSpecialResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetmenuItemSpecialById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{specialId}/{menuItemId}/detail", Name = "menuItemSpecialDetails")]
        public IActionResult GetmenuItemSpecialDetails(int specialId, int menuItemId)
        {
            try
            {
                var menuItemSpecial = _repository.MenuItem_Special.GetMenuItemSpecialWithDetails(specialId, menuItemId);
                if (menuItemSpecial == null)
                {
                    _logger.LogError($"menuItemSpecial with specialId id: {specialId} and menuItemId :{menuItemId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned menuItemSpecial with specialId id: {specialId} and menuItemId :{menuItemId} from database.");
                    var menuItemSpecialResult = _mapper.Map<MenuItem_SpecialDetailsDto>(menuItemSpecial);
                    return Ok(menuItemSpecialResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetmenuItemSpecialDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreatemenuItemSpecial([FromBody] MenuItem_SpecialForCreationDto menuItemSpecial)
        {
            try
            {
                if (menuItemSpecial == null)
                {
                    _logger.LogError("menuItemSpecial object sent from client is null.");
                    return BadRequest("menuItemSpecial object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid menuItemSpecial object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var menuItemSpecialEntity = _mapper.Map<MenuItemSpecial>(menuItemSpecial);

                _repository.MenuItem_Special.CreateMenuItemSpecial(menuItemSpecialEntity);
                _repository.Save();

                var createdmenuItemSpecial = _mapper.Map<MenuItem_SpecialDto>(menuItemSpecialEntity);

                return CreatedAtRoute("menuItemSpecialDetails", new { specialId = createdmenuItemSpecial.SpecialIdFk, menuItemId = createdmenuItemSpecial.MenuItemIdFk }, createdmenuItemSpecial);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreatemenuItemSpecial action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{specialId}/{menuItemId}")]
        public IActionResult UpdatemenuItemSpecial(int specialId, int menuItemId, [FromBody] MenuItem_SpecialForUpdateDto menuItemSpecial)
        {
            try
            {
                if (menuItemSpecial == null)
                {
                    _logger.LogError("menuItemSpecial object sent from client is null.");
                    return BadRequest("menuItemSpecial object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid menuItemSpecial object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var menuItemSpecialEntity = _repository.MenuItem_Special.GetMenuItemSpecialById(specialId, menuItemId);
                if (menuItemSpecialEntity == null)
                {
                    _logger.LogError($"menuItemSpecial with specialId: {specialId} and menuItemId: {menuItemId}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(menuItemSpecial, menuItemSpecialEntity);

                _repository.MenuItem_Special.UpdateMenuItemSpecial(menuItemSpecialEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdatemenuItemSpecial action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
