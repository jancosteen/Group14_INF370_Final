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
    [Route("api/supplierOrder")]
    [ApiController]
    public class SupplierOrderController : ControllerBase
    {
        //STEPS IN COMMENTS

        //1st: Inject logger and repo service in constructor: public SupplierController(ILoggerManager logger, IRepositoryWrapper repository)
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public SupplierOrderController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        //2nd Map to a GET function
        //IActionResult - Supports variety of methods AND status codes
        [HttpGet]
        public IActionResult GetAllSupplierOrders()
        {
            try
            {
                var supplierOrders = _repository.SupplierOrder.GetAllSupplierOrders();
                _logger.LogInfo($"Returned all supplierOrderss from database");

                var supplierOrdersResult = _mapper.Map<IEnumerable<SupplierOrderDto>>(supplierOrders);

                return Ok(supplierOrdersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllSupplierOrders() action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}", Name = "SupplierOrderById")]
        public IActionResult GetSupplierOrderById(int id)
        {
            try
            {
                var supOrder = _repository.SupplierOrder.GetSupplierOrderById(id);
                if (supOrder == null)
                {
                    _logger.LogError($"supOrder with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned supOrder with id: {id} from database.");
                    var supOrderResult = _mapper.Map<SupplierOrderDto>(supOrder);
                    return Ok(supOrderResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSupplierOrderById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/detail")]
        public IActionResult GetSupplierOrderWithDetails(int id)
        {
            try
            {
                var supOrders = _repository.SupplierOrder.GetSupplierOrderWithDetails(id);

                if (supOrders == null)
                {
                    _logger.LogError($"supOrders with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned supOrders with details for id: {id}");

                    var supOrdersResult = _mapper.Map<SupplierOrderDetailsDto>(supOrders);
                    return Ok(supOrdersResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSupplierOrderWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateSupplierOrder([FromBody] SupplierOrderForCreationDto sOrder)
        {
            try
            {
                if (sOrder == null)
                {
                    _logger.LogError("sOrder object sent from client is null.");
                    return BadRequest("sOrder object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid sOrder object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var sOrderEntity = _mapper.Map<SupplierOrder>(sOrder);

                _repository.SupplierOrder.CreateSupplierOrder(sOrderEntity);
                _repository.Save();

                var createdSOrder = _mapper.Map<SupplierOrderDto>(sOrderEntity);

                return CreatedAtRoute("SupplierOrderById", new { id = createdSOrder.SupplierOrderId }, createdSOrder);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSupplierOrder action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSupplierOrder(int id, [FromBody] SupplierOrderForUpdateDto sOrder)
        {
            try
            {
                if (sOrder == null)
                {
                    _logger.LogError("sOrder object sent from client is null.");
                    return BadRequest("sOrder object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid sOrder object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var sOrderEntity = _repository.SupplierOrder.GetSupplierOrderById(id);
                if (sOrderEntity == null)
                {
                    _logger.LogError($"sOrder with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(sOrder, sOrderEntity);

                _repository.SupplierOrder.UpdateSupplierOrder(sOrderEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSupplierOrder action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        //Still need to do delete but logic of what needs to be deleted is difficult
    }
}
