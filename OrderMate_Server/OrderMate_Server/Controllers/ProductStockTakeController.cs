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
    [Route("api/prodStockTake")]
    [ApiController]
    public class ProductStockTakeController : ControllerBase
    {
        //STEPS IN COMMENTS

        //1st: Inject logger and repo service in constructor: public SupplierController(ILoggerManager logger, IRepositoryWrapper repository)
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ProductStockTakeController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        //2nd Map to a GET function
        //IActionResult - Supports variety of methods AND status codes
        [HttpGet]
        public IActionResult GetAllProductStockTakes()
        {
            try
            {
                var prodStockTake = _repository.Product_Stock_Take.GetAllProductStockTakes();
                _logger.LogInfo($"Returned all prodStockTake records from database");

                var prodStockTakeResult = _mapper.Map<IEnumerable<ProductStockTakeDto>>(prodStockTake);

                return Ok(prodStockTakeResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllProductStockTakes() action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{prodId}/{stockTakeId}", Name = "ProductStockTakeById")]
        public IActionResult GetProductStockTakeById(int prodId, int stockTakeId)
        {
            try
            {
                var prodStockTake = _repository.Product_Stock_Take.GetProductStockTakeById(prodId, stockTakeId);
                if (prodStockTake == null)
                {
                    _logger.LogError($"prodStockTake with stockTake id: {stockTakeId} and prodId :{prodId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned prodStockTake with stockTake id: {stockTakeId} and prodId :{prodId} from database.");
                    var prodStockTakeResult = _mapper.Map<ProductStockTakeDto>(prodStockTake);
                    return Ok(prodStockTakeResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProductStockTakeById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{prodId}/{stockTakeId}/detail", Name = "ProductStockTakeDetails")]
        public IActionResult GetProductStockTakeDetails(int prodId, int stockTakeId)
        {
            try
            {
                var prodStockTake = _repository.Product_Stock_Take.GetProductStockTakeDetails(prodId, stockTakeId);
                if (prodStockTake == null)
                {
                    _logger.LogError($"ProductStockTake with stockTakeId id: {stockTakeId} and prodId :{prodId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned prodStockTake with stockTakeId id: {stockTakeId} and prodId :{prodId} from database.");
                    var prodStockTakeResult = _mapper.Map<ProductStockTakeDetailsDto>(prodStockTake);
                    return Ok(prodStockTakeResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProductStockTakeDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateProdStockTake([FromBody] ProductStockTakeForCreationDto prodStockTake)
        {
            try
            {
                if (prodStockTake == null)
                {
                    _logger.LogError("prodStockTake object sent from client is null.");
                    return BadRequest("prodStockTake object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid prodStockTake object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var prodStockTakeEntity = _mapper.Map<ProductStockTake>(prodStockTake);

                _repository.Product_Stock_Take.CreateProdStockTake(prodStockTakeEntity);
                _repository.Save();

                var createdProdStockTake = _mapper.Map<ProductStockTakeDto>(prodStockTakeEntity);

                return CreatedAtRoute("ProductStockTakeDetails", new { prodId = createdProdStockTake.ProductIdFk, stockTakeId = createdProdStockTake.StockTakeIdFk}, createdProdStockTake);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProdStockTake action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{prodId}/{stockTakeId}")]
        public IActionResult UpdateProdStockTake( int prodId, int stockTakeId, [FromBody] ProductStockTakeForUpdateDto prodStockTake)
        {
            try
            {
                if (prodStockTake == null)
                {
                    _logger.LogError("prodStockTake object sent from client is null.");
                    return BadRequest("prodStockTake object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid prodStockTake object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var prodStockTakeEntity = _repository.Product_Stock_Take.GetProductStockTakeById(prodId, stockTakeId);
                if (prodStockTakeEntity == null)
                {
                    _logger.LogError($"prodStockTake with stockTakeId: {stockTakeId} and prodId: {prodId}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(prodStockTake, prodStockTakeEntity);

                _repository.Product_Stock_Take.UpdateProdStockTake(prodStockTakeEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateProdStockTake action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
