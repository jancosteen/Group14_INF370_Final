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
    [Route("api/socialMediaType")]
    [ApiController]
    public class SocialMedia_TypeController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public SocialMedia_TypeController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllSocialMediaTypes()
        {
            try
            {
                var socialMediaTypes = _repository.SocialMedia_Type.GetAllSocialMediaTypes();
                _logger.LogInfo($"Returned all socialMediaTypes from db.");

                var socialMediaTypesResult = _mapper.Map<IEnumerable<SocialMedia_TypeDto>>(socialMediaTypes);
                return Ok(socialMediaTypesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllSocialMediaTypes action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "SocialMedia_TypeById")]
        public IActionResult GetSocialMedia_TypeById(int id)
        {
            try
            {
                var socialMediaType = _repository.SocialMedia_Type.GetSocialMediaTypeById(id);

                if (socialMediaType == null)
                {
                    _logger.LogError($"socialMediaType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned socialMediaType with id: {id}");

                    var socialMediaTypeResult = _mapper.Map<SocialMedia_TypeDto>(socialMediaType);
                    return Ok(socialMediaTypeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSocialMedia_TypeById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetSocialMedia_TypeWithDetails(int id)
        {
            try
            {
                var socialMediaType = _repository.SocialMedia_Type.GetSocialMediaTypeWithDetails(id);

                if (socialMediaType == null)
                {
                    _logger.LogError($"socialMediaType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"socialMediaType with details for id: {id}");

                    var socialMediaTypeResult = _mapper.Map<SocialMedia_TypeDetailsDto>(socialMediaType);
                    return Ok(socialMediaTypeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSocialMedia_TypeWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateSocialMedia_Type([FromBody] SocialMedia_TypeForCreationDto socialMediaType)
        {
            try
            {
                if (socialMediaType == null)
                {
                    _logger.LogError("socialMediaType object sent from client is null.");
                    return BadRequest("socialMediaType object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid socialMediaType object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var socialMediaTypeEntity = _mapper.Map<SocialMediaType>(socialMediaType);

                _repository.SocialMedia_Type.CreateSocialMediaType(socialMediaTypeEntity);
                _repository.Save();

                var createdSocialMedia_Type = _mapper.Map<SocialMedia_TypeDto>(socialMediaTypeEntity);

                return CreatedAtRoute("SocialMedia_TypeById", new { id = createdSocialMedia_Type.SocialMediaTypeId }, createdSocialMedia_Type);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSocialMedia_Type action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSocialMedia_Type(int id, [FromBody] SocialMedia_TypeForUpdateDto socialMediaType)
        {
            try
            {
                if (socialMediaType == null)
                {
                    _logger.LogError("socialMediaType object sent from client is null.");
                    return BadRequest("socialMediaType object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid socialMediaType object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var socialMediaTypeEntity = _repository.SocialMedia_Type.GetSocialMediaTypeById(id);
                if (socialMediaTypeEntity == null)
                {
                    _logger.LogError($"socialMediaType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(socialMediaType, socialMediaTypeEntity);

                _repository.SocialMedia_Type.UpdateSocialMediaType(socialMediaTypeEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSocialMedia_Type action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia_Type(int id)
        {
            try
            {
                var socialMediaType = _repository.SocialMedia_Type.GetSocialMediaTypeById(id);
                if (socialMediaType == null)
                {
                    _logger.LogError($"socialMediaType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.SocialMedia_Type.DeleteSocialMediaType(socialMediaType);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteSocialMedia_Type action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
