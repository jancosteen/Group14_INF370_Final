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
    [Route("api/attSheet")]
    [ApiController]
    public class AttendanceSheetController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public AttendanceSheetController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAttSheets()
        {
            try
            {
                var attSheets = _repository.Attendance_Sheet.GetAllAttendanceSeets();
                _logger.LogInfo($"Returned all attSheets from db.");

                var attSheetsResult = _mapper.Map<IEnumerable<AttendanceSheetDto>>(attSheets);
                return Ok(attSheetsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllAttSheets action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "AttendanceSheetById")]
        public IActionResult GetAttSheetById(int id)
        {
            try
            {
                var attSheet = _repository.Attendance_Sheet.GetAttendanceSheetById(id);

                if (attSheet == null)
                {
                    _logger.LogError($"attSheet with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned attSheet with id: {id}");

                    var attSheetResult = _mapper.Map<AttendanceSheetDto>(attSheet);
                    return Ok(attSheetResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAttSheetById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetAttSheetWithDetails(int id)
        {
            try
            {
                var attSheet = _repository.Attendance_Sheet.GetAttendanceSheetDetails(id);

                if (attSheet == null)
                {
                    _logger.LogError($"attSheet with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"attSheet with details for id: {id}");

                    var attSheetResult = _mapper.Map<AttendanceSheetDetailsDto>(attSheet);
                    return Ok(attSheetResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAttSheetWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateAttSheet([FromBody] AttendanceSheetForCreationDto attSheet)
        {
            try
            {
                if (attSheet == null)
                {
                    _logger.LogError("attSheet object sent from client is null.");
                    return BadRequest("attSheet object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid attSheet object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var attSheetEntity = _mapper.Map<AttendanceSheet>(attSheet);

                _repository.Attendance_Sheet.CreateAttSheet(attSheetEntity);
                _repository.Save();

                var createdAttSheet = _mapper.Map<AttendanceSheetDto>(attSheetEntity);

                return CreatedAtRoute("AttendanceSheetById", new { id = createdAttSheet.AttendanceSheetId }, createdAttSheet);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateAttSheet action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAttSheet(int id, [FromBody] AttendanceSheetForUpdateDto attSheet)
        {
            try
            {
                if (attSheet == null)
                {
                    _logger.LogError("attSheet object sent from client is null.");
                    return BadRequest("attSheet object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid attSheet object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var attSheetEntity = _repository.Attendance_Sheet.GetAttendanceSheetById(id);
                if (attSheetEntity == null)
                {
                    _logger.LogError($"attSheet with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(attSheet, attSheetEntity);

                _repository.Attendance_Sheet.UpdateAttSheet(attSheetEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateAttendanceSheet action: {ex.InnerException.Message}");
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
                _logger.LogError($"Something went wrong inside DeleteAttendanceSheet action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
