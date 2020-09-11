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
    [Route("api/qrCodeSeating")]
    [ApiController]
    public class QrCode_SeatingController : ControllerBase
    {
        //STEPS IN COMMENTS

        //1st: Inject logger and repo service in constructor: public SupplierController(ILoggerManager logger, IRepositoryWrapper repository)
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public QrCode_SeatingController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        //2nd Map to a GET function
        //IActionResult - Supports variety of methods AND status codes
        [HttpGet]
        public IActionResult GetAllQrCodeSeatingss()
        {
            try
            {
                var qrCodeSeatings = _repository.QrCode_Seating.GetAllQrCodeSeatings();
                _logger.LogInfo($"Returned all qrCodeSeatings records from database");

                var qrCodeSeatingsResult = _mapper.Map<IEnumerable<QrCode_SeatingDto>>(qrCodeSeatings);

                return Ok(qrCodeSeatingsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllQrCodeSeatings() action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{qrCodeId}/{seatingId}", Name = "QrCodeSeatingById")]
        public IActionResult GetQrCodeSeatingById(int qrCodeId, int seatingId)
        {
            try
            {
                var qrCodeSeating = _repository.QrCode_Seating.GetQrCodeSeatingById(qrCodeId, seatingId);
                if (qrCodeSeating == null)
                {
                    _logger.LogError($"qrCodeSeating with qrCodeId id: {qrCodeId} and seatingId :{seatingId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned qrCodeSeating with qrCodeId id: {qrCodeId} and seatingId :{seatingId} from database.");
                    var qrCodeSeatingResult = _mapper.Map<QrCode_SeatingDto>(qrCodeSeating);
                    return Ok(qrCodeSeatingResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetQrCodeSeatingById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{qrCodeId}/{seatingId}/detail", Name = "QrCodeSeatingDetails")]
        public IActionResult GetQrCodeSeatingDetails(int qrCodeId, int seatingId)
        {
            try
            {
                var qrCodeSeating = _repository.QrCode_Seating.GetQrCodeSeatingWithDetails(qrCodeId, seatingId);
                if (qrCodeSeating == null)
                {
                    _logger.LogError($"qrCodeSeating with qrCodeId id: {qrCodeId} and seatingId :{seatingId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned qrCodeSeating with qrCodeId id: {qrCodeId} and seatingId :{seatingId} from database.");
                    var qrCodeSeatingResult = _mapper.Map<QrCode_SeatingDetailsDto>(qrCodeSeating);
                    return Ok(qrCodeSeatingResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetQrCodeSeatingDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("{qrCodeIdFk}/{seatingIdFk}")]
        public IActionResult CreateQrCodeSeating([FromRoute] int qrCodeIdFk, int seatingIdFk)
        {
            try
            {
                if (qrCodeIdFk==0 || seatingIdFk==0)
                {
                    _logger.LogError("qrCodeSeating object sent from client is null.");
                    return BadRequest("qrCodeSeating object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid qrCodeSeating object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var qrCodeSeating = new QrCodeSeating()
                {
                    QrCodeIdFk = qrCodeIdFk,
                    SeatingIdFk = seatingIdFk,
                    NrOfPeople = 1
                };

                var qrCodeSeatingEntity = _mapper.Map<QrCodeSeating>(qrCodeSeating);

                _repository.QrCode_Seating.CreateQrCodeSeating(qrCodeSeatingEntity);
                _repository.Save();

                var createdQrCodeSeating = _mapper.Map<QrCode_SeatingDto>(qrCodeSeatingEntity);

                return CreatedAtRoute("QrCodeSeatingDetails", new { qrCodeId = createdQrCodeSeating.QrCodeIdFk, seatingId = createdQrCodeSeating.SeatingIdFk }, createdQrCodeSeating);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateQrCodeSeating action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{qrCodeId}/{seatingId}")]
        public IActionResult UpdateQrCodeSeating(int qrCodeId, int seatingId, [FromBody] QrCode_SeatingForUpdateDto qrCodeSeating)
        {
            try
            {
                if (qrCodeSeating == null)
                {
                    _logger.LogError("qrCodeSeating object sent from client is null.");
                    return BadRequest("qrCodeSeating object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid qrCodeSeating object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var qrCodeSeatingEntity = _repository.QrCode_Seating.GetQrCodeSeatingById(qrCodeId, seatingId);
                if (qrCodeSeatingEntity == null)
                {
                    _logger.LogError($"qrCodeSeating with qrCodeId: {qrCodeId} and seatingId: {seatingId}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(qrCodeSeating, qrCodeSeatingEntity);

                _repository.QrCode_Seating.UpdateQrCodeSeating(qrCodeSeatingEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateQrCodeSeating action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
