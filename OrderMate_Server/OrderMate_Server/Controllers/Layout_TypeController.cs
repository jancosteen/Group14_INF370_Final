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
    [Route("api/layoutType")]
    [ApiController]
    public class Layout_TypeController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Layout_TypeController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllLayoutTypes()
        {
            try
            {
                var layoutTypes = _repository.Layout_Type.GetAllLayoutTypess();
                _logger.LogInfo($"Returned all layoutTypes from db.");

                var layoutTypesResult = _mapper.Map<IEnumerable<Layout_TypeDto>>(layoutTypes);
                return Ok(layoutTypesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllLayoutTypes action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "Layout_TypeById")]
        public IActionResult GetLayout_TypeById(int id)
        {
            try
            {
                var layoutType = _repository.Layout_Type.GetLayoutTypeById(id);

                if (layoutType == null)
                {
                    _logger.LogError($"layoutType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned layoutType with id: {id}");

                    var layoutTypeResult = _mapper.Map<Layout_TypeDto>(layoutType);
                    return Ok(layoutTypeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetLayout_TypeById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetLayout_TypeWithDetails(int id)
        {
            try
            {
                var layoutType = _repository.Layout_Type.GetLayoutTypeWithDetails(id);

                if (layoutType == null)
                {
                    _logger.LogError($"layoutType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"layoutType with details for id: {id}");

                    var layoutTypeResult = _mapper.Map<Layout_TypeDetailsDto>(layoutType);
                    return Ok(layoutTypeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetLayout_TypeWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateLayout_Type([FromBody] Layout_TypeForCreationDto layoutType)
        {
            try
            {
                if (layoutType == null)
                {
                    _logger.LogError("layoutType object sent from client is null.");
                    return BadRequest("layoutType object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid layoutType object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var layoutTypeEntity = _mapper.Map<LayoutType>(layoutType);

                _repository.Layout_Type.CreateLayoutType(layoutTypeEntity);
                _repository.Save();

                var createdLayout_Type = _mapper.Map<Layout_TypeDto>(layoutTypeEntity);

                return CreatedAtRoute("Layout_TypeById", new { id = createdLayout_Type.LayoutTypeId }, createdLayout_Type);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateLayout_Type action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLayout_Type(int id, [FromBody] Layout_TypeForUpdateDto layoutType)
        {
            try
            {
                if (layoutType == null)
                {
                    _logger.LogError("layoutType object sent from client is null.");
                    return BadRequest("layoutType object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid layoutType object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var layoutTypeEntity = _repository.Layout_Type.GetLayoutTypeById(id);
                if (layoutTypeEntity == null)
                {
                    _logger.LogError($"layoutType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(layoutType, layoutTypeEntity);

                _repository.Layout_Type.UpdateLayoutType(layoutTypeEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateLayout_Type action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLayout_Type(int id)
        {
            try
            {
                var layoutType = _repository.Layout_Type.GetLayoutTypeById(id);
                if (layoutType == null)
                {
                    _logger.LogError($"layoutType with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Layout_Type.DeleteLayoutType(layoutType);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteLayout_Type action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
