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
    [Route("api/writtenOffStock")]
    [ApiController]
    public class Written_Off_StockController : ControllerBase
    {
        //STEPS IN COMMENTS

        //1st: Inject logger and repo service in constructor: public SupplierController(ILoggerManager logger, IRepositoryWrapper repository)
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Written_Off_StockController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        //2nd Map to a GET function
        //IActionResult - Supports variety of methods AND status codes
        [HttpGet]
        public IActionResult GetAllWrittenOffStocks()
        {
            try
            {
                var prodWOS = _repository.Written_Off_Stock.GetAllWrittenOffStocks();
                _logger.LogInfo($"Returned all  written off stocks records from database");

                var prodWOSResult = _mapper.Map<IEnumerable<WrittenOffStockDto>>(prodWOS);

                return Ok(prodWOSResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllWrittenOffStocks() action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}", Name = "WrittenOffStockById")]
        public IActionResult GetWrittenOffStockById(int id)
        {
            try
            {
                var wos = _repository.Written_Off_Stock.GetWrittenOffStockById(id);

                if (wos == null)
                {
                    _logger.LogError($"wos with id: {id} , hasn't been found in the db");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned wos with id: {id}");

                    var wosResult = _mapper.Map<WrittenOffStockDto>(wos);
                    return Ok(wosResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetWrittenOffStockById() action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}/detail", Name = "WrittenOffStockDetails")]
        public IActionResult GetWrittenOffStockDetails(int id)
        {
            try
            {
                var wos = _repository.Written_Off_Stock.GetWrittenOffStockDetails(id);

                if (wos == null)
                {
                    _logger.LogError($"wos with id: {id} , hasn't been found in the db");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned wos with id: {id}");

                    var wosResult = _mapper.Map<WrittenOffStockDetailsDto>(wos);
                    return Ok(wosResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetWrittenOffStockDetails() action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        public IActionResult CreateWrittenOffStock([FromBody] WrittenOffStockForCreationDto writtenOffStock)
        {
            try
            {
                if (writtenOffStock == null)
                {
                    _logger.LogError("writtenOffStock object sent from client is null.");
                    return BadRequest("writtenOffStock object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid writtenOffStock object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var writtenOffStockEntity = _mapper.Map<WrittenOffStock>(writtenOffStock);

                _repository.Written_Off_Stock.CreateWrittenOfStock(writtenOffStockEntity);
                _repository.Save();

                var createdWrittenOffStock = _mapper.Map<WrittenOffStockDto>(writtenOffStockEntity);

                return CreatedAtRoute("WrittenOffStockDetails", new { id = createdWrittenOffStock.WrittenOfStockId }, createdWrittenOffStock);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateWrittenOffStock action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateWrittenOffStock(int id, [FromBody] WrittenOffStockForUpdateDto writtenOffStock)
        {
            try
            {
                if (writtenOffStock == null)
                {
                    _logger.LogError("writtenOffStock object sent from client is null.");
                    return BadRequest("writtenOffStock object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid writtenOffStock object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var writtenOffStockEntity = _repository.Written_Off_Stock.GetWrittenOffStockById(id);
                if (writtenOffStockEntity == null)
                {
                    _logger.LogError($"writtenOffStock with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(writtenOffStock, writtenOffStockEntity);

                _repository.Written_Off_Stock.UpdateWrittenOfStock(writtenOffStockEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateWrittenOffStock action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
