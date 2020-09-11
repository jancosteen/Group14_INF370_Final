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
    [Route("api/qrCode")]
    [ApiController]
    public class QrCodeController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public QrCodeController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllQrCodes()
        {
            try
            {
                var qrCodes = _repository.QrCode.GetAllQrCodes();
                _logger.LogInfo($"Returned all qrCodes from db.");

                var qrCodesResult = _mapper.Map<IEnumerable<QrCodeDto>>(qrCodes);
                return Ok(qrCodesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllQrCodes action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "QrCodeById")]
        public IActionResult GetQrCodeById(int id)
        {
            try
            {
                var qrCode = _repository.QrCode.GetQrCodeById(id);

                if (qrCode == null)
                {
                    _logger.LogError($"qrCode with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned qrCode with id: {id}");

                    var qrCodeResult = _mapper.Map<QrCodeDto>(qrCode);
                    return Ok(qrCodeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetQrCodeById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetQrCodeWithDetails(int id)
        {
            try
            {
                var qrCode = _repository.QrCode.GetQrCodeWithDetails(id);

                if (qrCode == null)
                {
                    _logger.LogError($"qrCode with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"qrCode with details for id: {id}");

                    var qrCodeResult = _mapper.Map<QrCodeDetailsDto>(qrCode);
                    return Ok(qrCodeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetQrCodeWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateQrCode([FromBody] QrCodeForCreationDto qrCode)
        {
            try
            {
                if (qrCode == null)
                {
                    _logger.LogError("qrCode object sent from client is null.");
                    return BadRequest("qrCode object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid qrCode object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var qrCodeEntity = _mapper.Map<QrCode>(qrCode);

                _repository.QrCode.CreateQrCode(qrCodeEntity);
                _repository.Save();

                var createdQrCode = _mapper.Map<QrCodeDto>(qrCodeEntity);

                return CreatedAtRoute("QrCodeById", new { id = createdQrCode.QrCodeId }, createdQrCode);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateQrCode action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateQrCode(int id, [FromBody] QrCodeForUpdateDto qrCode)
        {
            try
            {
                if (qrCode == null)
                {
                    _logger.LogError("qrCode object sent from client is null.");
                    return BadRequest("qrCode object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid qrCode object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var qrCodeEntity = _repository.QrCode.GetQrCodeById(id);
                if (qrCodeEntity == null)
                {
                    _logger.LogError($"qrCode with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(qrCode, qrCodeEntity);

                _repository.QrCode.UpdateQrCode(qrCodeEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateQrCode action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQrCode(int id)
        {
            try
            {
                var qrCode = _repository.QrCode.GetQrCodeById(id);
                if (qrCode == null)
                {
                    _logger.LogError($"qrCode with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.QrCode.DeleteQrCode(qrCode);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteQrCode action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
