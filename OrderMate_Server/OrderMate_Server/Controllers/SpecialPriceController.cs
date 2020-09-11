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
    [Route("api/specialPrice")]
    [ApiController]
    public class SpecialPriceController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public SpecialPriceController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllSpecialPrices()
        {
            try
            {
                var specialPrices = _repository.Special_Price.GetAllSpecialPricees();
                _logger.LogInfo($"Returned all specialPrices from db.");

                var specialPricesResult = _mapper.Map<IEnumerable<SpecialPriceDto>>(specialPrices);
                return Ok(specialPricesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllSpecialPrices action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "Special_PriceById")]
        public IActionResult GetSpecial_PriceById(int id)
        {
            try
            {
                var specialPrice = _repository.Special_Price.GetSpecialPriceById(id);

                if (specialPrice == null)
                {
                    _logger.LogError($"specialPrice with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned specialPrice with id: {id}");

                    var specialPriceResult = _mapper.Map<SpecialPriceDto>(specialPrice);
                    return Ok(specialPriceResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSpecial_PriceById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetSpecial_PriceWithDetails(int id)
        {
            try
            {
                var specialPrice = _repository.Special_Price.GetSpecialPriceWithDetails(id);

                if (specialPrice == null)
                {
                    _logger.LogError($"specialPrice with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"specialPrice with details for id: {id}");

                    var specialPriceResult = _mapper.Map<SpecialPriceDetailsDto>(specialPrice);
                    return Ok(specialPriceResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSpecial_PriceWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateSpecial_Price([FromBody] SpecialPriceForCreationDto specialPrice)
        {
            try
            {
                if (specialPrice == null)
                {
                    _logger.LogError("specialPrice object sent from client is null.");
                    return BadRequest("specialPrice object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid specialPrice object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var specialPriceEntity = _mapper.Map<SpecialPrice>(specialPrice);

                _repository.Special_Price.CreateSpecialPrice(specialPriceEntity);
                _repository.Save();

                var createdSpecial_Price = _mapper.Map<SpecialPriceDto>(specialPriceEntity);

                return CreatedAtRoute("Special_PriceById", new { id = createdSpecial_Price.SpecialPriceId }, createdSpecial_Price);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSpecial_Price action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSpecial_Price(int id, [FromBody] SpecialPriceForUpdateDto specialPrice)
        {
            try
            {
                if (specialPrice == null)
                {
                    _logger.LogError("specialPrice object sent from client is null.");
                    return BadRequest("specialPrice object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid specialPrice object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var specialPriceEntity = _repository.Special_Price.GetSpecialPriceById(id);
                if (specialPriceEntity == null)
                {
                    _logger.LogError($"specialPrice with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(specialPrice, specialPriceEntity);

                _repository.Special_Price.UpdateSpecialPrice(specialPriceEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSpecial_Price action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSpecial_Price(int id)
        {
            try
            {
                var specialPrice = _repository.Special_Price.GetSpecialPriceById(id);
                if (specialPrice == null)
                {
                    _logger.LogError($"specialPrice with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Special_Price.DeleteSpecialPrice(specialPrice);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteSpecial_Price action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
