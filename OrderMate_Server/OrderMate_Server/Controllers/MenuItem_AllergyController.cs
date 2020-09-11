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
    [Route("api/menuItemAllergy")]
    [ApiController]
    public class MenuItem_AllergyController : ControllerBase
    {
        //STEPS IN COMMENTS

        //1st: Inject logger and repo service in constructor: public SupplierController(ILoggerManager logger, IRepositoryWrapper repository)
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public MenuItem_AllergyController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        //2nd Map to a GET function
        //IActionResult - Supports variety of methods AND status codes
        [HttpGet]
        public IActionResult GetAllMenuItemAllergiess()
        {
            try
            {
                var menuItemAllergies = _repository.MenuItem_Allergy.GetAllMenuItemAllergies();
                _logger.LogInfo($"Returned all menuItemAllergies records from database");

                var menuItemAllergiesResult = _mapper.Map<IEnumerable<MenuItem_AllergyDto>>(menuItemAllergies);

                return Ok(menuItemAllergiesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllMenuItemAllergies() action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{allergyId}/{menuItemId}", Name = "MenuItemAllergyById")]
        public IActionResult GetMenuItemAllergyById(int allergyId, int menuItemId)
        {
            try
            {
                var menuItemAllergy = _repository.MenuItem_Allergy.GetMenuItemAllergyById(allergyId, menuItemId);
                if (menuItemAllergy == null)
                {
                    _logger.LogError($"menuItemAllergy with allergyId id: {allergyId} and menuItemId :{menuItemId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned menuItemAllergy with allergyId id: {allergyId} and menuItemId :{menuItemId} from database.");
                    var menuItemAllergyResult = _mapper.Map<MenuItem_AllergyDto>(menuItemAllergy);
                    return Ok(menuItemAllergyResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMenuItemAllergyById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{allergyId}/{menuItemId}/detail", Name = "MenuItemAllergyDetails")]
        public IActionResult GetMenuItemAllergyDetails(int allergyId, int menuItemId)
        {
            try
            {
                var menuItemAllergy = _repository.MenuItem_Allergy.GetMenuItemAllergyWithDetails(allergyId, menuItemId);
                if (menuItemAllergy == null)
                {
                    _logger.LogError($"menuItemAllergy with allergyId id: {allergyId} and menuItemId :{menuItemId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned menuItemAllergy with allergyId id: {allergyId} and menuItemId :{menuItemId} from database.");
                    var menuItemAllergyResult = _mapper.Map<MenuItem_AllergyDetailsDto>(menuItemAllergy);
                    return Ok(menuItemAllergyResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMenuItemAllergyDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateMenuItemAllergy([FromBody] MenuItem_AllergyForCreationDto menuItemAllergy)
        {
            try
            {
                if (menuItemAllergy == null)
                {
                    _logger.LogError("menuItemAllergy object sent from client is null.");
                    return BadRequest("menuItemAllergy object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid menuItemAllergy object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var menuItemAllergyEntity = _mapper.Map<MenuItemAllergy>(menuItemAllergy);

                _repository.MenuItem_Allergy.CreateMenuItemAllergy(menuItemAllergyEntity);
                _repository.Save();

                var createdMenuItemAllergy = _mapper.Map<MenuItem_AllergyDto>(menuItemAllergyEntity);

                return CreatedAtRoute("MenuItemAllergyDetails", new { allergyId = createdMenuItemAllergy.AllergyIdFk, menuItemId = createdMenuItemAllergy.MenuItemIdFk }, createdMenuItemAllergy);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateMenuItemAllergy action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{allergyId}/{menuItemId}")]
        public IActionResult UpdateMenuItemAllergy(int allergyId, int menuItemId, [FromBody] MenuItem_AllergyForUpdateDto menuItemAllergy)
        {
            try
            {
                if (menuItemAllergy == null)
                {
                    _logger.LogError("menuItemAllergy object sent from client is null.");
                    return BadRequest("menuItemAllergy object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid menuItemAllergy object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var menuItemAllergyEntity = _repository.MenuItem_Allergy.GetMenuItemAllergyById(allergyId, menuItemId);
                if (menuItemAllergyEntity == null)
                {
                    _logger.LogError($"menuItemAllergy with allergyId: {allergyId} and menuItemId: {menuItemId}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(menuItemAllergy, menuItemAllergyEntity);

                _repository.MenuItem_Allergy.UpdateMenuItemAllergy(menuItemAllergyEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateMenuItemAllergy action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
