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
    [Route("api/prodWrittenOff")]
    [ApiController]
    public class Product_Written_OffController : ControllerBase
    {
        //STEPS IN COMMENTS

        //1st: Inject logger and repo service in constructor: public SupplierController(ILoggerManager logger, IRepositoryWrapper repository)
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Product_Written_OffController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        //2nd Map to a GET function
        //IActionResult - Supports variety of methods AND status codes
        [HttpGet]
        public IActionResult GetAllProductWrittenOffs()
        {
            try
            {
                var prodWO = _repository.Product_Written_Off.GetAllProductWrittenOffs();
                _logger.LogInfo($"Returned all product written off records from database");

                var prodWOResult = _mapper.Map<IEnumerable<ProductWrittenOffDto>>(prodWO);

                return Ok(prodWOResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllProductWrittenOffs() action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{woStockId}/{prodId}", Name = "ProductWrittenOffById")]
        public IActionResult GetProductWrittenOffById(int woStockId, int prodId)
        {
            try
            {
                var prodWo = _repository.Product_Written_Off.GetProductWrittenOffById(woStockId, prodId);
                if (prodWo == null)
                {
                    _logger.LogError($"Product Written Off with writeOfStock id: {woStockId} and prodId :{prodId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned prodWo with writeOffStock id: {woStockId} and prodId :{prodId} from database.");
                    var prodWoResult = _mapper.Map<ProductWrittenOffDto>(prodWo);
                    return Ok(prodWoResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProductWrittenOffById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{woStockId}/{prodId}/detail", Name = "ProductWrittenOffDetails")]
        public IActionResult GetProductWrittenOffDetails(int woStockId, int prodId)
        {
            try
            {
                var prodWo = _repository.Product_Written_Off.GetProductWrittenOffDetails(woStockId, prodId);
                if (prodWo == null)
                {
                    _logger.LogError($"Product Written Off with writeOfStock id: {woStockId} and prodId :{prodId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned prodWo with writeOffStock id: {woStockId} and prodId :{prodId} from database.");
                    var prodWoResult = _mapper.Map<ProductWrittenOffDetailsDto>(prodWo);
                    return Ok(prodWoResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProductWrittenOffDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateProductWrittenOff([FromBody] ProductWrittenOffForCreationDto productWrittenOff)
        {
            try
            {
                if (productWrittenOff == null)
                {
                    _logger.LogError("productWrittenOff object sent from client is null.");
                    return BadRequest("productWrittenOff object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid productWrittenOff object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var productWrittenOffEntity = _mapper.Map<ProductWrittenOff>(productWrittenOff);

                _repository.Product_Written_Off.CreateProductWrittenOff(productWrittenOffEntity);
                _repository.Save();

                var createdProductWrittenOff = _mapper.Map<ProductWrittenOffDto>(productWrittenOffEntity);

                return CreatedAtRoute("ProductWrittenOffDetails", new { woStockId = createdProductWrittenOff.WrittenOffStockIdFk, prodId = createdProductWrittenOff.ProductIdFk }, createdProductWrittenOff);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProductWrittenOff action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{woStockId}/{prodId}")]
        public IActionResult UpdateProductWrittenOff(int woStockId, int prodId, [FromBody] ProductWrittenOffForUpdateDto prodWo)
        {
            try
            {
                if (prodWo == null)
                {
                    _logger.LogError("prodWo object sent from client is null.");
                    return BadRequest("prodWo object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid prodWo object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var prodWoEntity = _repository.Product_Written_Off.GetProductWrittenOffById(woStockId, prodId);
                if (prodWoEntity == null)
                {
                    _logger.LogError($"prodWo with woStockId: {woStockId} and prodId: {prodId}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(prodWo, prodWoEntity);

                _repository.Product_Written_Off.UpdateProductWrittenOff(prodWoEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateProductWrittenOff action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


    }
}
