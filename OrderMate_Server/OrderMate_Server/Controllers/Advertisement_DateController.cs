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
    [Route("api/advDate")]
    [ApiController]
    public class Advertisement_DateController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Advertisement_DateController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAdvertisementDates()
        {
            try
            {
                var advertisementDates = _repository.Advertisement_Date.GetAllAdvDates();
                _logger.LogInfo($"Returned all advertisementDates from db.");

                var advertisementDatesResult = _mapper.Map<IEnumerable<Advertisement_DateDto>>(advertisementDates);
                return Ok(advertisementDatesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllAdvertisementDates action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "Advertisement_DateById")]
        public IActionResult GetAdvertisement_DateById(int id)
        {
            try
            {
                var advertisement_Date = _repository.Advertisement_Date.GetAdvDateById(id);

                if (advertisement_Date == null)
                {
                    _logger.LogError($"advertisement_Date with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned advertisement_Date with id: {id}");

                    var advertisement_DateResult = _mapper.Map<Advertisement_DateDto>(advertisement_Date);
                    return Ok(advertisement_DateResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAdvertisement_DateById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetAdvertisement_DateWithDetails(int id)
        {
            try
            {
                var advertisement_Date = _repository.Advertisement_Date.GetAdvDateWithDetails(id);

                if (advertisement_Date == null)
                {
                    _logger.LogError($"advertisement_Date with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"advertisement_Date with details for id: {id}");

                    var advertisement_DateResult = _mapper.Map<Advertisement_DateDetailsDto>(advertisement_Date);
                    return Ok(advertisement_DateResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAdvertisement_DateWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateAdvertisement_Date([FromBody] Advertisement_DateForCreationDto advertisement_Date)
        {
            try
            {
                if (advertisement_Date == null)
                {
                    _logger.LogError("advertisement_Date object sent from client is null.");
                    return BadRequest("advertisement_Date object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid advertisement_Date object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var advertisement_DateEntity = _mapper.Map<AdvertisementDate>(advertisement_Date);

                _repository.Advertisement_Date.CreateAdvDate(advertisement_DateEntity);
                _repository.Save();

                var createdAdvertisement_Date = _mapper.Map<Advertisement_DateDto>(advertisement_DateEntity);

                return CreatedAtRoute("Advertisement_DateById", new { id = createdAdvertisement_Date.AdvertisementDateId }, createdAdvertisement_Date);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAdvertisement_Date action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAdvertisement_Date(int id, [FromBody] Advertisement_DateForUpdateDto advertisement_Date)
        {
            try
            {
                if (advertisement_Date == null)
                {
                    _logger.LogError("advertisement_Date object sent from client is null.");
                    return BadRequest("advertisement_Date object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid advertisement_Date object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var advertisement_DateEntity = _repository.Advertisement_Date.GetAdvDateById(id);
                if (advertisement_DateEntity == null)
                {
                    _logger.LogError($"advertisement_Date with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(advertisement_Date, advertisement_DateEntity);

                _repository.Advertisement_Date.UpdateAdvDate(advertisement_DateEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateAdvertisement_Date action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdvertisement_Date(int id)
        {
            try
            {
                var advertisement_Date = _repository.Advertisement_Date.GetAdvDateById(id);
                if (advertisement_Date == null)
                {
                    _logger.LogError($"advertisement_Date with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Advertisement_Date.DeleteAdvDate(advertisement_Date);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteAdvertisement_Date action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
