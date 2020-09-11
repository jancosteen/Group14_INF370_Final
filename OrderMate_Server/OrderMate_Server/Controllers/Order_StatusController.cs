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
    [Route("api/orderStatus")]
    [ApiController]
    public class Order_StatusController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Order_StatusController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllOrderStatusses()
        {
            try
            {
                var orderStatusses = _repository.Order_Status.GetAllOrderStatusses();
                _logger.LogInfo($"Returned all orderStatusses from db.");

                var orderStatussesResult = _mapper.Map<IEnumerable<Order_StatusDto>>(orderStatusses);
                return Ok(orderStatussesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllOrderStatusses action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "Order_StatusById")]
        public IActionResult GetOrder_StatusById(int id)
        {
            try
            {
                var orderStatus = _repository.Order_Status.GetOrderStatusById(id);

                if (orderStatus == null)
                {
                    _logger.LogError($"orderStatus with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned orderStatus with id: {id}");

                    var orderStatusResult = _mapper.Map<Order_StatusDto>(orderStatus);
                    return Ok(orderStatusResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOrder_StatusById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetOrder_StatusWithDetails(int id)
        {
            try
            {
                var orderStatus = _repository.Order_Status.GetOrderStatusWithDetails(id);

                if (orderStatus == null)
                {
                    _logger.LogError($"orderStatus with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"orderStatus with details for id: {id}");

                    var orderStatusResult = _mapper.Map<Order_StatusDetailsDto>(orderStatus);
                    return Ok(orderStatusResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOrder_StatusWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateOrder_Status([FromBody] Order_StatusForCreationDto orderStatus)
        {
            try
            {
                if (orderStatus == null)
                {
                    _logger.LogError("orderStatus object sent from client is null.");
                    return BadRequest("orderStatus object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid orderStatus object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var orderStatusEntity = _mapper.Map<OrderStatus>(orderStatus);

                _repository.Order_Status.CreateOrderStatus(orderStatusEntity);
                _repository.Save();

                var createdOrder_Status = _mapper.Map<Order_StatusDto>(orderStatusEntity);

                return CreatedAtRoute("Order_StatusById", new { id = createdOrder_Status.OrderStatusId}, createdOrder_Status);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOrder_Status action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder_Status(int id, [FromBody] Order_StatusForUpdateDto orderStatus)
        {
            try
            {
                if (orderStatus == null)
                {
                    _logger.LogError("orderStatus object sent from client is null.");
                    return BadRequest("orderStatus object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid orderStatus object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var orderStatusEntity = _repository.Order_Status.GetOrderStatusById(id);
                if (orderStatusEntity == null)
                {
                    _logger.LogError($"orderStatus with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(orderStatus, orderStatusEntity);

                _repository.Order_Status.UpdateOrderStatus(orderStatusEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOrder_Status action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder_Status(int id)
        {
            try
            {
                var orderStatus = _repository.Order_Status.GetOrderStatusById(id);
                if (orderStatus == null)
                {
                    _logger.LogError($"orderStatus with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Order_Status.DeleteOrderStatus(orderStatus);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOrder_Status action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
