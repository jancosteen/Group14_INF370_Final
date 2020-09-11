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
    [Route("api/stockTake")]
    [ApiController]
    public class StockTakeController : ControllerBase
    {
        //STEPS IN COMMENTS

        //1st: Inject logger and repo service in constructor: public SupplierController(ILoggerManager logger, IRepositoryWrapper repository)
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public StockTakeController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        //2nd Map to a GET function
        //IActionResult - Supports variety of methods AND status codes
        [HttpGet]
        public IActionResult GetAllStockTakes()
        {
            try
            {
                var stockTakes = _repository.Stock_Take.GetAllStockTakes();
                _logger.LogInfo($"Returned all  stockTakes records from database");

                var stockTakesResult = _mapper.Map<IEnumerable<StockTakeDto>>(stockTakes);

                return Ok(stockTakesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllStockTakes() action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}", Name = "StockTakeById")]
        public IActionResult GetStockTakeById(int id)
        {
            try
            {
                var stockTake = _repository.Stock_Take.GetStockTakeById(id);

                if (stockTake == null)
                {
                    _logger.LogError($"stockTake with id: {id} , hasn't been found in the db");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned stockTake with id: {id}");

                    var stockTakeResult = _mapper.Map<StockTakeDto>(stockTake);
                    return Ok(stockTakeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetStockTakeById() action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}/detail", Name = "StockTakeDetails")]
        public IActionResult GetStockTakeDetails(int id)
        {
            try
            {
                var stockTake = _repository.Stock_Take.GetStockTakeDetails(id);

                if (stockTake == null)
                {
                    _logger.LogError($"stockTake with id: {id} , hasn't been found in the db");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned stockTake with id: {id}");

                    var stockTakeResult = _mapper.Map<StockTakeDetailsDto>(stockTake);
                    return Ok(stockTakeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetStockTakeDetails() action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult CreateStockTake([FromBody] StockTakeForCreationDto stockTake)
        {
            try
            {
                if (stockTake == null)
                {
                    _logger.LogError("stockTake object sent from client is null.");
                    return BadRequest("stockTake object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid stockTake object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var stockTakeEntity = _mapper.Map<StockTake>(stockTake);

                _repository.Stock_Take.CreateStockTake(stockTakeEntity);
                _repository.Save();

                var createdStockTake = _mapper.Map<StockTakeDto>(stockTakeEntity);

                return CreatedAtRoute("StockTakeDetails", new { id = createdStockTake.StockTakeId }, createdStockTake);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateStockTake action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStockTake(int id, [FromBody] StockTakeForUpdateDto stockTake)
        {
            try
            {
                if (stockTake == null)
                {
                    _logger.LogError("stockTake object sent from client is null.");
                    return BadRequest("stockTake object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid stockTake object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var stockTakeEntity = _repository.Stock_Take.GetStockTakeById(id);
                if (stockTakeEntity == null)
                {
                    _logger.LogError($"stockTake with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(stockTake, stockTakeEntity);

                _repository.Stock_Take.UpdateStockTake(stockTakeEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateStockTake action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
