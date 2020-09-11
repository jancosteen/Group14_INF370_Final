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
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ProductController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var prods = _repository.Product.GetAllProducts();
                _logger.LogInfo($"Returned all products from database.");

                var prodsResult = _mapper.Map<IEnumerable<ProductDto>>(prods);
                return Ok(prodsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllProducts action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "ProductById")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _repository.Product.GetProductById(id);

                if (product == null)
                {
                    _logger.LogError($"Product with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned product with id: {id}");

                    var productResult = _mapper.Map<ProductDto>(product);
                    return Ok(productResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProductById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetProductWithDetails(int id)
        {
            try
            {
                var product = _repository.Product.GetProductWithDetails(id);

                if (product == null)
                {
                    _logger.LogError($"Product with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned product with details for id: {id}");

                    var productResult = _mapper.Map<ProductDetailsDto>(product);
                    return Ok(productResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProductWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductForCreationDto product)
        {
            try
            {
                if (product == null)
                {
                    _logger.LogError("product object sent from client is null.");
                    return BadRequest("product object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid product object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var productEntity = _mapper.Map<Product>(product);

                _repository.Product.CreateProduct(productEntity);
                _repository.Save();

                var createdProduct = _mapper.Map<ProductDto>(productEntity);

                return CreatedAtRoute("ProductTypeById", new { id = createdProduct.ProductId }, createdProduct);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProduct action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody]ProductForUpdateDto product)
        {
            try
            {
                if (product == null)
                {
                    _logger.LogError("product object sent from client is null.");
                    return BadRequest("product object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid product object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var productEntity = _repository.Product.GetProductById(id);
                if (productEntity == null)
                {
                    _logger.LogError($"product with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(product, productEntity);

                _repository.Product.UpdateProduct(productEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateProduct action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _repository.Product.GetProductById(id);
                if (product == null)
                {
                    _logger.LogError($"Product with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                
                if (_repository.SupplierOrderLine.SupplierOrderLinesByProduct(id).Any())
                {
                    _logger.LogError($"Cannot delete product with id: {id}. It has related supplierOrderLines. Delete those SupplierOrderLines first");
                    return BadRequest("Cannot delete product. It has related supplierOrderLines. Delete those supplierOrderLines first");
                }

                if (_repository.Product_Stock_Take.StockTakeByProduct(id).Any())
                {
                    _logger.LogError($"Cannot delete product with id: {id}. It has related stockTakes. Delete those stockTakes first");
                    return BadRequest("Cannot delete product. It has related stockTakes. Delete those stockTakes first");
                }

                if (_repository.Product_Written_Off.WrittenOffByProduct(id).Any())
                {
                    _logger.LogError($"Cannot delete product with id: {id}. It has related writtenOffLines. Delete those writtenOffLines first");
                    return BadRequest("Cannot delete product. It has related writtenOffLines. Delete those writtenOffLines first");
                }

                _repository.Product.DeleteProduct(product);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteProduct action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
