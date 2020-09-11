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
    [Route("api/reservationStatus")]
    [ApiController]
    public class Reservation_StatusController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Reservation_StatusController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllReservation_Statusses()
        {
            try
            {
                var reservationStatusses = _repository.Reservation_Status.GetAllReservationStatusses();
                _logger.LogInfo($"Returned all reservationStatusses from db.");

                var reservationStatussesResult = _mapper.Map<IEnumerable<ReservationStatusDto>>(reservationStatusses);
                return Ok(reservationStatussesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllReservation_Statusses action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "Reservation_StatusById")]
        public IActionResult GetReservation_StatusById(int id)
        {
            try
            {
                var reservationStatus = _repository.Reservation_Status.GetReservationStatusById(id);

                if (reservationStatus == null)
                {
                    _logger.LogError($"reservationStatus with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned reservationStatus with id: {id}");

                    var reservationStatusResult = _mapper.Map<ReservationStatusDto>(reservationStatus);
                    return Ok(reservationStatusResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetReservation_StatusById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetReservation_StatusWithDetails(int id)
        {
            try
            {
                var reservationStatus = _repository.Reservation_Status.GetReservationStatusWithDetails(id);

                if (reservationStatus == null)
                {
                    _logger.LogError($"reservationStatus with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"reservationStatus with details for id: {id}");

                    var reservationStatusResult = _mapper.Map<ReservationStatusDetailsDto>(reservationStatus);
                    return Ok(reservationStatusResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetReservation_StatusWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateReservation_Status([FromBody] ReservationStatusForCreationDto reservationStatus)
        {
            try
            {
                if (reservationStatus == null)
                {
                    _logger.LogError("reservationStatus object sent from client is null.");
                    return BadRequest("reservationStatus object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid reservationStatus object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var reservationStatusEntity = _mapper.Map<ReservationStatus>(reservationStatus);

                _repository.Reservation_Status.CreateReservationStatus(reservationStatusEntity);
                _repository.Save();

                var createdReservation_Status = _mapper.Map<ReservationStatusDto>(reservationStatusEntity);

                return CreatedAtRoute("Reservation_StatusById", new { id = createdReservation_Status.ReservationStatusId }, createdReservation_Status);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateReservation_Status action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReservation_Status(int id, [FromBody] ReservationStatusForUpdateDto reservationStatus)
        {
            try
            {
                if (reservationStatus == null)
                {
                    _logger.LogError("reservationStatus object sent from client is null.");
                    return BadRequest("reservationStatus object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid reservationStatus object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var reservationStatusEntity = _repository.Reservation_Status.GetReservationStatusById(id);
                if (reservationStatusEntity == null)
                {
                    _logger.LogError($"reservationStatus with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(reservationStatus, reservationStatusEntity);

                _repository.Reservation_Status.UpdateReservationStatus(reservationStatusEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateReservation_Status action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReservation_Status(int id)
        {
            try
            {
                var reservationStatus = _repository.Reservation_Status.GetReservationStatusById(id);
                if (reservationStatus == null)
                {
                    _logger.LogError($"reservationStatus with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Reservation_Status.DeleteReservationStatus(reservationStatus);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteReservation_Status action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
