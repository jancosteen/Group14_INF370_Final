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
    [Route("api/socialMedia")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public SocialMediaController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllSocialMedias()
        {
            try
            {
                var socialMedias = _repository.SocialMedia.GetAllSocialMedias();
                _logger.LogInfo($"Returned all socialMedias from db.");

                var socialMediasResult = _mapper.Map<IEnumerable<SocialMediaDto>>(socialMedias);
                return Ok(socialMediasResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllSocialMedias action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "SocialMediaById")]
        public IActionResult GetSocialMediaById(int id)
        {
            try
            {
                var socialMedia = _repository.SocialMedia.GetSocialMediaById(id);

                if (socialMedia == null)
                {
                    _logger.LogError($"socialMedia with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned socialMedia with id: {id}");

                    var socialMediaResult = _mapper.Map<SocialMediaDto>(socialMedia);
                    return Ok(socialMediaResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSocialMediaById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetSocialMediaWithDetails(int id)
        {
            try
            {
                var socialMedia = _repository.SocialMedia.GetSocialMediaDetails(id);

                if (socialMedia == null)
                {
                    _logger.LogError($"socialMedia with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"socialMedia with details for id: {id}");

                    var socialMediaResult = _mapper.Map<SocialMediaDetailsDto>(socialMedia);
                    return Ok(socialMediaResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSocialMediaWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateSocialMedia([FromBody] SocialMediaForCreationDto socialMedia)
        {
            try
            {
                if (socialMedia == null)
                {
                    _logger.LogError("socialMedia object sent from client is null.");
                    return BadRequest("socialMedia object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid socialMedia object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var socialMediaEntity = _mapper.Map<SocialMedia>(socialMedia);

                _repository.SocialMedia.CreateSocialMedia(socialMediaEntity);
                _repository.Save();

                var createdSocialMedia = _mapper.Map<SocialMediaDto>(socialMediaEntity);

                return CreatedAtRoute("SocialMediaById", new { id = createdSocialMedia.SocialMediaId }, createdSocialMedia);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSocialMedia action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSocialMedia(int id, [FromBody] SocialMediaForUpdateDto socialMedia)
        {
            try
            {
                if (socialMedia == null)
                {
                    _logger.LogError("socialMedia object sent from client is null.");
                    return BadRequest("socialMedia object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid socialMedia object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var socialMediaEntity = _repository.SocialMedia.GetSocialMediaById(id);
                if (socialMediaEntity == null)
                {
                    _logger.LogError($"socialMedia with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(socialMedia, socialMediaEntity);

                _repository.SocialMedia.UpdateSocialMedia(socialMediaEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSocialMedia action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            try
            {
                var socialMedia = _repository.SocialMedia.GetSocialMediaById(id);
                if (socialMedia == null)
                {
                    _logger.LogError($"socialMedia with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.SocialMedia.DeleteSocialMedia(socialMedia);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteSocialMedia action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
