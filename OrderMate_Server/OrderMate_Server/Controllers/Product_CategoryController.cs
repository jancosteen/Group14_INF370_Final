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
    [Route("api/prodCategory")]
    [ApiController]
    public class Product_CategoryController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Product_CategoryController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProductCategories()
        {
            try
            {
                var prodCats = _repository.Product_Category.GetAllProductCategories();
                _logger.LogInfo($"Returned all product categories from db.");

                var prodCatsResult = _mapper.Map<IEnumerable<ProductCategoryDto>>(prodCats);
                return Ok(prodCatsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllProductCategories action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
                
            }
        }

        [HttpGet("{id}", Name = "ProductCategoryById")]
        public IActionResult GetProductCategoryById(int id)
        {
            try
            {
                var prodCat = _repository.Product_Category.GetProductCategoryById(id);

                if (prodCat == null)
                {
                    _logger.LogError($"Product Category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned product category with id: {id}");

                    var prodCatResult = _mapper.Map<ProductCategoryDto>(prodCat);
                    return Ok(prodCatResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProductCategoryById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/product")]
        public IActionResult GetProductCategoryWithDetails(int id)
        {
            try
            {
                var prodCat = _repository.Product_Category.GetProductCategoryWithProducts(id);

                if (prodCat == null)
                {
                    _logger.LogError($"Product Category with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned product category with details for id: {id}");

                    var prodCatResult = _mapper.Map<ProductCategoryDetailsDto>(prodCat);
                    return Ok(prodCatResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetProductCategoryWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateProductCategory([FromBody] ProductCategoryForCreationDto prodCategory)
        {
            try
            {
                if (prodCategory == null)
                {
                    _logger.LogError("prodCategory object sent from client is null.");
                    return BadRequest("prodCategory object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid prodCategory object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var prodCategoryEntity = _mapper.Map<ProductCategory>(prodCategory);

                _repository.Product_Category.CreateProdCategory(prodCategoryEntity);
                _repository.Save();

                var createdProdCategory = _mapper.Map<ProductCategoryDto>(prodCategoryEntity);

                return CreatedAtRoute("ProductCategoryById", new { id = createdProdCategory.ProductCategoryId }, createdProdCategory);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProdCategory action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductCategory(int id, [FromBody] ProductCategoryForUpdateDto prodCat)
        {
            try
            {
                if (prodCat == null)
                {
                    _logger.LogError("prodCat object sent from client is null.");
                    return BadRequest("prodCat object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid prodCat object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var prodCatEntity = _repository.Product_Category.GetProductCategoryById(id);
                if (prodCatEntity == null)
                {
                    _logger.LogError($"prodCat with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(prodCat, prodCatEntity);

                _repository.Product_Category.UpdateProdCategory(prodCatEntity);
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
        public IActionResult DeleteProductCategory(int id)
        {
            try
            {
                var prodCat = _repository.Product_Category.GetProductCategoryById(id);
                if (prodCat == null)
                {
                    _logger.LogError($"prodCat with id: {id}, hasn't been found in db.");
                    return NotFound();
                }                

                _repository.Product_Category.DeleteProdCategory(prodCat);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteProductCategory action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
