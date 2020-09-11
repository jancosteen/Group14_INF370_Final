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
    [Route("api/advertisement")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public AdvertisementController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAdvertisements()
        {
            try
            {
                var advertisements = _repository.Advertisement.GetAllAdvertisements();
                _logger.LogInfo($"Returned all advertisements from db.");

                var advertisementsResult = _mapper.Map<IEnumerable<AdvertisementDto>>(advertisements);
                return Ok(advertisementsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllAdvertisements action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "AdvertisementById")]
        public IActionResult GetAdvertisementById(int id)
        {
            try
            {
                var advertisement = _repository.Advertisement.GetAdvertisementById(id);

                if (advertisement == null)
                {
                    _logger.LogError($"advertisement with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned advertisement with id: {id}");

                    var advertisementResult = _mapper.Map<AdvertisementDto>(advertisement);
                    return Ok(advertisementResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAdvertisementById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetAdvertisementWithDetails(int id)
        {
            try
            {
                var advertisement = _repository.Advertisement.GetAdvertisementWithDetails(id);

                if (advertisement == null)
                {
                    _logger.LogError($"advertisement with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"advertisement with details for id: {id}");

                    var advertisementResult = _mapper.Map<AdvertisementDetailsDto>(advertisement);
                    return Ok(advertisementResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAdvertisementWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateAdvertisement([FromBody] AdvertisementForCreationDto advertisement)
        {
            try
            {
                if (advertisement == null)
                {
                    _logger.LogError("advertisement object sent from client is null.");
                    return BadRequest("advertisement object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid advertisement object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var advertisementEntity = _mapper.Map<Advertisement>(advertisement);

                _repository.Advertisement.CreateAdvertisement(advertisementEntity);
                _repository.Save();

                var createdAdvertisement = _mapper.Map<AdvertisementDto>(advertisementEntity);

                return CreatedAtRoute("AdvertisementById", new { id = createdAdvertisement.AdvertisementId }, createdAdvertisement);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAdvertisement action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAdvertisement(int id, [FromBody] AdvertisementForUpdateDto advertisement)
        {
            try
            {
                if (advertisement == null)
                {
                    _logger.LogError("advertisement object sent from client is null.");
                    return BadRequest("advertisement object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid advertisement object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var advertisementEntity = _repository.Advertisement.GetAdvertisementById(id);
                if (advertisementEntity == null)
                {
                    _logger.LogError($"advertisement with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(advertisement, advertisementEntity);

                _repository.Advertisement.UpdateAdvertisement(advertisementEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateAdvertisement action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdvertisement(int id)
        {
            try
            {
                var advertisement = _repository.Advertisement.GetAdvertisementById(id);
                if (advertisement == null)
                {
                    _logger.LogError($"advertisement with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Advertisement.DeleteAdvertisement(advertisement);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteAdvertisement action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
