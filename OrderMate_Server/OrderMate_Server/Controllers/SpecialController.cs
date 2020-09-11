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
    [Route("api/special")]
    [ApiController]
    public class SpecialController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public SpecialController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllSpecials()
        {
            try
            {
                var specials = _repository.Special.GetAllSpecials();
                _logger.LogInfo($"Returned all specials from db.");

                var specialsResult = _mapper.Map<IEnumerable<SpecialDto>>(specials);
                return Ok(specialsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllSpecials action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "SpecialById")]
        public IActionResult GetSpecialById(int id)
        {
            try
            {
                var special = _repository.Special.GetSpecialById(id);

                if (special == null)
                {
                    _logger.LogError($"special with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned special with id: {id}");

                    var specialResult = _mapper.Map<SpecialDto>(special);
                    return Ok(specialResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSpecialById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetSpecialWithDetails(int id)
        {
            try
            {
                var special = _repository.Special.GetSpecialWithDetails(id);

                if (special == null)
                {
                    _logger.LogError($"special with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"special with details for id: {id}");

                    var specialResult = _mapper.Map<SpecialDetailsDto>(special);
                    return Ok(specialResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSpecialWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateSpecial([FromBody] SpecialForCreationDto special)
        {
            try
            {
                if (special == null)
                {
                    _logger.LogError("special object sent from client is null.");
                    return BadRequest("special object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid special object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var specialEntity = _mapper.Map<Special>(special);

                _repository.Special.CreateSpecial(specialEntity);
                _repository.Save();

                var createdSpecial = _mapper.Map<SpecialDto>(specialEntity);

                return CreatedAtRoute("SpecialById", new { id = createdSpecial.SpecialId }, createdSpecial);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSpecial action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSpecial(int id, [FromBody] SpecialForUpdateDto special)
        {
            try
            {
                if (special == null)
                {
                    _logger.LogError("special object sent from client is null.");
                    return BadRequest("special object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid special object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var specialEntity = _repository.Special.GetSpecialById(id);
                if (specialEntity == null)
                {
                    _logger.LogError($"special with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(special, specialEntity);

                _repository.Special.UpdateSpecial(specialEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSpecial action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSpecial(int id)
        {
            try
            {
                var special = _repository.Special.GetSpecialById(id);
                if (special == null)
                {
                    _logger.LogError($"special with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Special.DeleteSpecial(special);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteSpecial action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
