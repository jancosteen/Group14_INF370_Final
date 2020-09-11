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
    [Route("api/advPrice")]
    [ApiController]
    public class Advertisment_PriceController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Advertisment_PriceController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAdvertisementPrices()
        {
            try
            {
                var advertisementPrices = _repository.Advertisement_Price.GetAllAdvPrices();
                _logger.LogInfo($"Returned all advertisementPrices from db.");

                var advertisementPricesResult = _mapper.Map<IEnumerable<Advertisement_PriceDto>>(advertisementPrices);
                return Ok(advertisementPricesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllAdvertisementPrices action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "Advertisement_PriceById")]
        public IActionResult GetAdvertisement_PriceById(int id)
        {
            try
            {
                var advertisementPrice = _repository.Advertisement_Price.GetAdvertisementPriceById(id);

                if (advertisementPrice == null)
                {
                    _logger.LogError($"advertisementPrice with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned advertisementPrice with id: {id}");

                    var advertisementPriceResult = _mapper.Map<Advertisement_PriceDto>(advertisementPrice);
                    return Ok(advertisementPriceResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAdvertisement_PriceById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetAdvertisement_PriceWithDetails(int id)
        {
            try
            {
                var advertisementPrice = _repository.Advertisement_Price.GetAdvertisementPriceWithDetails(id);

                if (advertisementPrice == null)
                {
                    _logger.LogError($"advertisementPrice with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"advertisementPrice with details for id: {id}");

                    var advertisementPriceResult = _mapper.Map<Advertisement_PriceDetailsDto>(advertisementPrice);
                    return Ok(advertisementPriceResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAdvertisement_PriceWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateAdvertisement_Price([FromBody] Advertisement_PriceForCreationDto advertisementPrice)
        {
            try
            {
                if (advertisementPrice == null)
                {
                    _logger.LogError("advertisementPrice object sent from client is null.");
                    return BadRequest("advertisementPrice object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid advertisementPrice object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var advertisementPriceEntity = _mapper.Map<AdvertisementPrice>(advertisementPrice);

                _repository.Advertisement_Price.CreateAdvertisementPrice(advertisementPriceEntity);
                _repository.Save();

                var createdAdvertisement_Price = _mapper.Map<Advertisement_PriceDto>(advertisementPriceEntity);

                return CreatedAtRoute("Advertisement_PriceById", new { id = createdAdvertisement_Price.AdvertisementPriceId }, createdAdvertisement_Price);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAdvertisement_Price action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAdvertisement_Price(int id, [FromBody] Advertisement_PriceForUpdateDto advertisementPrice)
        {
            try
            {
                if (advertisementPrice == null)
                {
                    _logger.LogError("advertisementPrice object sent from client is null.");
                    return BadRequest("advertisementPrice object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid advertisementPrice object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var advertisementPriceEntity = _repository.Advertisement_Price.GetAdvertisementPriceById(id);
                if (advertisementPriceEntity == null)
                {
                    _logger.LogError($"advertisementPrice with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(advertisementPrice, advertisementPriceEntity);

                _repository.Advertisement_Price.UpdateAdvertisementPrice(advertisementPriceEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateAdvertisement_Price action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdvertisement_Price(int id)
        {
            try
            {
                var advertisementPrice = _repository.Advertisement_Price.GetAdvertisementPriceById(id);
                if (advertisementPrice == null)
                {
                    _logger.LogError($"advertisementPrice with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Advertisement_Price.DeleteAdvertisementPrice(advertisementPrice);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteAdvertisement_Price action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
