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
    [Route("api/orderLine")]
    [ApiController]
    public class Order_LineController : ControllerBase
    {

        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Order_LineController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllOrderLines()
        {
            try
            {
                var orderLines = _repository.Order_Line.GetAllOrderLines();
                _logger.LogInfo($"Returned all orderLines from db.");

                var orderLinesResult = _mapper.Map<IEnumerable<Order_LineDto>>(orderLines);
                return Ok(orderLinesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllOrderLines action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}", Name = "Order_LineById")]
        public IActionResult GetOrder_LineById(int id)
        {
            try
            {
                var orderLine = _repository.Order_Line.GetOrderLineById(id);

                if (orderLine == null)
                {
                    _logger.LogError($"orderLine with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned orderLine with id: {id}");

                    var orderLineResult = _mapper.Map<Order_LineDto>(orderLine);
                    return Ok(orderLineResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOrder_LineById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetOrder_LineWithDetails(int id)
        {
            try
            {
                var orderLine = _repository.Order_Line.GetOrderLineWithDetails(id);

                if (orderLine == null)
                {
                    _logger.LogError($"orderLine with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"orderLine with details for id: {id}");

                    var orderLineResult = _mapper.Map<Order_LineDetailsDto>(orderLine);
                    return Ok(orderLineResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOrder_LineWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateOrder_Line([FromBody] Order_LineForCreationDto orderLine)
        {
            try
            {
                if (orderLine == null)
                {
                    _logger.LogError("orderLine object sent from client is null.");
                    return BadRequest("orderLine object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid orderLine object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var orderLineEntity = _mapper.Map<OrderLine>(orderLine);

                _repository.Order_Line.CreateOrderLine(orderLineEntity);
                _repository.Save();

                var createdOrder_Line = _mapper.Map<Order_LineDto>(orderLineEntity);

                return CreatedAtRoute("Order_LineById", new { id = createdOrder_Line.OrderLineId }, createdOrder_Line);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOrder_Line action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder_Line(int id, [FromBody] Order_LineForUpdateDto orderLine)
        {
            try
            {
                if (orderLine == null)
                {
                    _logger.LogError("orderLine object sent from client is null.");
                    return BadRequest("orderLine object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid orderLine object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var orderLineEntity = _repository.Order_Line.GetOrderLineById(id);
                if (orderLineEntity == null)
                {
                    _logger.LogError($"orderLine with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(orderLine, orderLineEntity);

                _repository.Order_Line.UpdateOrderLine(orderLineEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOrder_Line action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder_Line(int id)
        {
            try
            {
                var orderLine = _repository.Order_Line.GetOrderLineById(id);
                if (orderLine == null)
                {
                    _logger.LogError($"orderLine with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _repository.Order_Line.DeleteOrderLine(orderLine);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOrder_Line action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
