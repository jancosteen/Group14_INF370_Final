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
    [Route("api/allergy")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public AllergyController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAllergies()
        {
            try
            {
                var allergies = _repository.Allergy.GetAllAllergies();
                _logger.LogInfo($"Returned all allergies from db.");

                var allergiesResult = _mapper.Map<IEnumerable<AllergyDto>>(allergies);
                return Ok(allergiesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllAllergies action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "AllergyById")]
        public IActionResult GetAllergyById(int id)
        {
            try
            {
                var allergy = _repository.Allergy.GetAllergyById(id);

                if (allergy == null)
                {
                    _logger.LogError($"allergy with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned allergy with id: {id}");

                    var allergyResult = _mapper.Map<AllergyDto>(allergy);
                    return Ok(allergyResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllergyById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetAllergyWithDetails(int id)
        {
            try
            {
                var allergy = _repository.Allergy.GetAllergyWithDetails(id);

                if (allergy == null)
                {
                    _logger.LogError($"allergy with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"allergy with details for id: {id}");

                    var allergyResult = _mapper.Map<AllergyDetailsDto>(allergy);
                    return Ok(allergyResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllergyWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateAllergy([FromBody] AllergyForCreationDto allergy)
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

                var allergyEntity = _mapper.Map<Allergy>(allergy);

                _repository.Allergy.CreateAllergy(allergyEntity);
                _repository.Save();

                var createdAllergy = _mapper.Map<AllergyDto>(allergyEntity);

                return CreatedAtRoute("AllergyById", new { id = createdAllergy.AllergyId }, createdAllergy);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAllergy action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAllergy(int id, [FromBody] AllergyForUpdateDto allergy)
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

                var allergyEntity = _repository.Allergy.GetAllergyById(id);
                if (allergyEntity == null)
                {
                    _logger.LogError($"allergy with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(allergy, allergyEntity);

                _repository.Allergy.UpdateAllergy(allergyEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateAllergy action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAllergy(int id)
        {
            try
            {
                var allergy = _repository.Allergy.GetAllergyById(id);
                if (allergy == null)
                {
                    _logger.LogError($"allergy with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Allergy.DeleteAllergy(allergy);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteAllergy action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
