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
    [Route("api/prodReorderFreq")]
    [ApiController]
    public class Product_Reorder_FreqController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Product_Reorder_FreqController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProductReorderFreqs()
        {
            try
            {
                var prodReorderFreqs = _repository.Product_Reorder_Freq.GetAllProductReorderFreqs();
                _logger.LogInfo($"Returned all product reorder frequencies from db.");

                var prodReorderFreqsResult = _mapper.Map<IEnumerable<ProductReorderFreqDto>>(prodReorderFreqs);

                return Ok(prodReorderFreqsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllProductReorderFreqs action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name ="ProductReorderFreqById")]
        public IActionResult GetProductReorderFreqById(int id)
        {
            try
            {
                var prodReorder = _repository.Product_Reorder_Freq.GetProductReorderFreqById(id);

                if (prodReorder == null)
                {
                    _logger.LogError($"Product Reorder Frequency with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned product reorder Frequency with id: {id}");

                    var prodReorderResult = _mapper.Map<ProductReorderFreqDto>(prodReorder);
                    return Ok(prodReorderResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProductReorderFreqById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/product")]
        public IActionResult GetProductReorderFreqWithDetails(int id)
        {
            try
            {
                var prodRFreq = _repository.Product_Reorder_Freq.GetProductReorderFreqWithProducts(id);

                if (prodRFreq == null)
                {
                    _logger.LogError($"Product Reorder Freq with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned product reorder Freg with details for id: {id}");

                    var prodRFreqResult = _mapper.Map<ProductReorderFreqDetailsDto>(prodRFreq);
                    return Ok(prodRFreqResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProductReorderFrequencyWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateProductReorderFreq([FromBody] ProductReorderFreqForCreationDto prodRFreq)
        {
            try
            {
                if (prodRFreq == null)
                {
                    _logger.LogError("prodRFreq object sent from client is null.");
                    return BadRequest("prodRFreq object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid prodRFreq object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var prodRFreqEntity = _mapper.Map<ProductReorderFreq>(prodRFreq);

                _repository.Product_Reorder_Freq.CreateProdRFreq(prodRFreqEntity);
                _repository.Save();

                var createdProdRFreq = _mapper.Map<ProductReorderFreqDto>(prodRFreqEntity);

                return CreatedAtRoute("ProductReorderFreqById", new { id = createdProdRFreq.ProductReorderFreqId }, createdProdRFreq);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProdReorderFreq action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductReorderFreq(int id, [FromBody] ProductReorderFreqForUpdateDto prodRFreq)
        {
            try
            {
                if (prodRFreq == null)
                {
                    _logger.LogError("prodRFreq object sent from client is null.");
                    return BadRequest("prodRFreq object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid prodRFreq object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var prodRFreqEntity = _repository.Product_Reorder_Freq.GetProductReorderFreqById(id);
                if (prodRFreqEntity == null)
                {
                    _logger.LogError($"prodRFreq with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(prodRFreq, prodRFreqEntity);

                _repository.Product_Reorder_Freq.UpdateProdRFreq(prodRFreqEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateProductType action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductReorderFreq(int id)
        {
            try
            {
                var prodRFreq = _repository.Product_Reorder_Freq.GetProductReorderFreqById(id);
                if (prodRFreq == null)
                {
                    _logger.LogError($"prodRFreq with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Product_Reorder_Freq.DeleteProdRFreq(prodRFreq);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteProductReorderFreq action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
