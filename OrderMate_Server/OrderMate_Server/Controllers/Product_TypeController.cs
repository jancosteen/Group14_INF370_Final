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
    [Route("api/prodType")]
    [ApiController]
    public class Product_TypeController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Product_TypeController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProductTypes()
        {
            try
            {
                var prodTypes = _repository.Product_Type.GetAllProductTypes();
                _logger.LogInfo($"Returned all product types from database.");

                var prodTypesResult = _mapper.Map<IEnumerable<ProductTypeDto>>(prodTypes);
                return Ok(prodTypesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllProductTypes action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "ProductTypeById")]
        public IActionResult GetProductTypeById(int id)
        {
            try
            {
                var prodType = _repository.Product_Type.GetProductTypeById(id);
                if (prodType == null)
                {
                    _logger.LogError($"Product Type with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned product type with id: {id} from database.");
                    var prodTypeResult = _mapper.Map<ProductTypeDto>(prodType);
                    return Ok(prodTypeResult);
                }          
                                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProductTypeById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}/product")]
        public IActionResult GetProductTypeWithDetails(int id)
        {
            try
            {
                var prodType = _repository.Product_Type.GetProductTypeWithProducts(id);

                if (prodType == null)
                {
                    _logger.LogError($"Product Type with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned product type with details for id: {id}");

                    var prodTypeResult = _mapper.Map<ProductTypeDetailsDto>(prodType);
                    return Ok(prodTypeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProductTypeWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateProductType([FromBody] ProductTypeForCreationDto prodType)
        {
            try
            {
                if (prodType == null)
                {
                    _logger.LogError("prodType object sent from client is null.");
                    return BadRequest("prodType object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid prodType object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var prodTypeEntity = _mapper.Map<ProductType>(prodType);

                _repository.Product_Type.CreateProdType(prodTypeEntity);
                _repository.Save();

                var createdProdType = _mapper.Map<ProductTypeDto>(prodTypeEntity);

                return CreatedAtRoute("ProductTypeById", new { id = createdProdType.ProductTypeId }, createdProdType);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProdType action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductType(int id, [FromBody]ProductTypeForUpdateDto prodType)
        {
            try
            {
                if (prodType == null)
                {
                    _logger.LogError("prodType object sent from client is null.");
                    return BadRequest("prodType object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid prodType object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var prodTypeEntity = _repository.Product_Type.GetProductTypeById(id);
                if (prodTypeEntity == null)
                {
                    _logger.LogError($"prodType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(prodType, prodTypeEntity);

                _repository.Product_Type.UpdateProdType(prodTypeEntity);
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
        public IActionResult DeleteProductType(int id)
        {
            try
            {
                var prodType = _repository.Product_Type.GetProductTypeById(id);
                if (prodType == null)
                {
                    _logger.LogError($"prodType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Product_Type.DeleteProdType(prodType);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteProductType action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
