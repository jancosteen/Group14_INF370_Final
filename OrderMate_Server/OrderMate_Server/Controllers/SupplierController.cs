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
using NLog.Fluent;

namespace OrderMate_Server.Controllers
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        //STEPS IN COMMENTS

        //1st: Inject logger and repo service in constructor: public SupplierController(ILoggerManager logger, IRepositoryWrapper repository)
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public SupplierController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        //2nd Map to a GET function
        //IActionResult - Supports variety of methods AND status codes
        [HttpGet]
        public IActionResult GetAllSuppliers()
        {
            try
            {
                var suppliers = _repository.Supplier.GetAllSuppliers();
                _logger.LogInfo($"Returned all suppliers from database");

                var suppliersResult = _mapper.Map<IEnumerable<SupplierDto>>(suppliers);

                return Ok(suppliersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllSuppliers() action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}", Name = "SupplierById")]
        public IActionResult GetSupplierById(int id)
        {
            try
            {
                var supplier = _repository.Supplier.GetSupplierById(id);

                if (supplier == null)
                {
                    _logger.LogError($"Supplier with id: {id} , hasn't been found in the db");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned supplier with id: {id}");

                    var supplierResult = _mapper.Map<SupplierDto>(supplier);
                    return Ok(supplierResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetSupplierById() action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}/supplierOrder")]
        public IActionResult GetSupplierWithOrderDetails(int id)
        {
            try
            {
                var supplier = _repository.Supplier.GetSupplierWithOrderDetails(id);

                if (supplier == null)
                {
                    _logger.LogError($"Supplier with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned supplier with SupplierOrder details for id: {id}");
                    var supplierResult = _mapper.Map<SupplierDetailsDto>(supplier);

                    return Ok(supplierResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSupplierWithOrderDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateSupplier([FromBody] SupplierForCreationDto supplier)
        {
            try
            {
                if (supplier == null)
                {
                    _logger.LogError("Supplier object sent from client is null.");
                    return BadRequest("Supplier object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid supplier object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var supplierEntity = _mapper.Map<Supplier>(supplier);

                _repository.Supplier.CreateSupplier(supplierEntity);
                _repository.Save();

                var createdSupplier = _mapper.Map<SupplierDto>(supplierEntity);

                return CreatedAtRoute("SupplierById", new { id = createdSupplier.SupplierId }, createdSupplier);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSupplier action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSupplier (int id, [FromBody]SupplierForUpdateDto supplier)
        {
            try
            {
                if(supplier == null)
                {
                    _logger.LogError("Supplier object sent from client is null.");
                    return BadRequest("Supplier object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid supplier object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var supplierEntity = _repository.Supplier.GetSupplierById(id);
                if (supplierEntity == null)
                {
                    _logger.LogError($"Supplier with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(supplier, supplierEntity);

                _repository.Supplier.UpdateSupplier(supplierEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSupplier action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(int id)
        {
            try
            {
                var supplier = _repository.Supplier.GetSupplierById(id);
                if (supplier == null)
                {
                    _logger.LogError($"Supplier with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                if (_repository.SupplierOrder.SupplierOrdersBySupplier(id).Any())
                {
                    _logger.LogError($"Cannot delete supplier with id: {id}. It has related supplierOrders. Delete those SupplierOrders first");
                    return BadRequest("Cannot delete supplier. It has related supplierOrders. Delete those supplierOrders first");
                }

                _repository.Supplier.DeleteSupplier(supplier);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteSupplier action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
