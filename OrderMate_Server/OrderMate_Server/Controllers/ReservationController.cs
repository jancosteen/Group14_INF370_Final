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
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ReservationController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllReservations()
        {
            try
            {
                var reservations = _repository.Reservation.GetAllReservations();
                _logger.LogInfo($"Returned all reservations from db.");

                var reservationsResult = _mapper.Map<IEnumerable<ReservationDto>>(reservations);
                return Ok(reservationsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllReservations action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{userId}/userId", Name = "ReservationByUserId")]
        public IActionResult GetAllReservationsByUserId(string userId)
        {
            try
            {
                var reservations = _repository.Reservation.GetAllReservationByUserId(userId);
                _logger.LogInfo($"Returned all reservations from db.");

                var reservationsResult = _mapper.Map<IEnumerable<ReservationDto>>(reservations);
                return Ok(reservationsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllReservations action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "ReservationById")]
        public IActionResult GetReservationById(int id)
        {
            try
            {
                var reservation = _repository.Reservation.GetReservationById(id);

                if (reservation == null)
                {
                    _logger.LogError($"reservation with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned reservation with id: {id}");

                    var reservationResult = _mapper.Map<ReservationDto>(reservation);
                    return Ok(reservationResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetReservationById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetReservationWithDetails(int id)
        {
            try
            {
                var reservation = _repository.Reservation.GetReservationWithDetails(id);

                if (reservation == null)
                {
                    _logger.LogError($"reservation with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"reservation with details for id: {id}");

                    var reservationResult = _mapper.Map<ReservationDetailsDto>(reservation);
                    return Ok(reservationResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetReservationWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateReservation([FromBody] ReservationForCreationDto reservation)
        {
            try
            {
                if (reservation == null)
                {
                    _logger.LogError("reservation object sent from client is null.");
                    return BadRequest("reservation object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid reservation object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var reservationEntity = _mapper.Map<Reservation>(reservation);

                _repository.Reservation.CreateReservation(reservationEntity);
                _repository.Save();

                var createdReservation = _mapper.Map<ReservationDto>(reservationEntity);

                return CreatedAtRoute("ReservationById", new { id = createdReservation.ReservationId }, createdReservation);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateReservation action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReservation(int id, [FromBody] ReservationForUpdateDto reservation)
        {
            try
            {
                if (reservation == null)
                {
                    _logger.LogError("reservation object sent from client is null.");
                    return BadRequest("reservation object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid reservation object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var reservationEntity = _repository.Reservation.GetReservationById(id);
                if (reservationEntity == null)
                {
                    _logger.LogError($"reservation with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(reservation, reservationEntity);

                _repository.Reservation.UpdateReservation(reservationEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateReservation action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReservation(int id)
        {
            try
            {
                var reservation = _repository.Reservation.GetReservationById(id);
                if (reservation == null)
                {
                    _logger.LogError($"reservation with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Reservation.DeleteReservation(reservation);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteReservation action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
