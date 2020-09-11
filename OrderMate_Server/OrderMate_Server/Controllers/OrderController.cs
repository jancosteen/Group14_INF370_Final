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
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public OrderController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;

            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            try
            {
                var orders = _repository.Order.GetAllOrders();
                _logger.LogInfo($"Returned all orders from db.");

                var ordersResult = _mapper.Map<IEnumerable<OrderDto>>(orders);
                return Ok(ordersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllOrders action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "OrderById")]
        public IActionResult GetOrderById(int id)
        {
            try
            {
                var order = _repository.Order.GetOrderById(id);

                if (order == null)
                {
                    _logger.LogError($"order with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned order with id: {id}");

                    var orderResult = _mapper.Map<OrderDto>(order);
                    return Ok(orderResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOrderById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetOrderWithDetails(int id)
        {
            try
            {
                var order = _repository.Order.GetOrderWithDetails(id);

                if (order == null)
                {
                    _logger.LogError($"order with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"order with details for id: {id}");

                    var orderResult = _mapper.Map<OrderDetailsDto>(order);
                    return Ok(orderResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOrderWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderForCreationDto order)
        {
            try
            {
                if (order == null)
                {
                    _logger.LogError("order object sent from client is null.");
                    return BadRequest("order object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid order object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var orderEntity = _mapper.Map<Order>(order);

                _repository.Order.CreateOrder(orderEntity);
                _repository.Save();

                var createdOrder = _mapper.Map<OrderDto>(orderEntity);

                return CreatedAtRoute("OrderById", new { id = createdOrder.OrderId }, createdOrder);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOrder action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderForUpdateDto order)
        {
            try
            {
                if (order == null)
                {
                    _logger.LogError("order object sent from client is null.");
                    return BadRequest("order object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid order object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var orderEntity = _repository.Order.GetOrderById(id);
                if (orderEntity == null)
                {
                    _logger.LogError($"order with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(order, orderEntity);

                _repository.Order.UpdateOrder(orderEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOrder action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            try
            {
                var order = _repository.Order.GetOrderById(id);
                if (order == null)
                {
                    _logger.LogError($"order with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Order.DeleteOrder(order);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOrder action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
