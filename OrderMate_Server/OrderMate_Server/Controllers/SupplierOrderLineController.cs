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
    [Route("api/supOrderLine")]
    [ApiController]
    public class SupplierOrderLineController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public SupplierOrderLineController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllSupplierOrderLines()
        {
            try
            {
                var supOLines = _repository.SupplierOrderLine.GetSupplierOrderLines();
                _logger.LogInfo($"Returned all supOLines from db.");

                var supOLinesResult = _mapper.Map<IEnumerable<SupplierOrderLineDto>>(supOLines);
                return Ok(supOLinesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetAllSupplierOrderLines action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet("{id}/sOrderId", Name = "SupOrderLineBySupOrderId")]
        public IActionResult GetSupOrderLineBySupplierOrderId(int id)
        {
            try
            {
                var supOrderLine = _repository.SupplierOrderLine.GetSupOrderLineBySupplierOrderId(id);
                if (supOrderLine == null)
                {
                    _logger.LogError($"supOrderLine with supOrder id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned supOrderLine with supOrder id: {id} from database.");
                    var supOrderLineResult = _mapper.Map<SupplierOrderLineDto>(supOrderLine);
                    return Ok(supOrderLineResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSupOrderLineBySupplierOrderId action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{sOrderId}/{prodId}", Name = "SupOrderLineBySupOrderIdAndProdId")]
        public IActionResult GetSupOrderLineBySupplierOrderIdAndProdId(int sOrderId, int prodId)
        {
            try
            {
                var supOrderLine = _repository.SupplierOrderLine.GetSupOrderLineBySupplierOrderIdAndProdId(sOrderId, prodId);
                if (supOrderLine == null)
                {
                    _logger.LogError($"supOrderLine with supOrder id: {sOrderId} and prodId :{prodId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned supOrderLine with supOrder id: {sOrderId} and prodId :{prodId} from database.");
                    var supOrderLineResult = _mapper.Map<SupplierOrderLineDto>(supOrderLine);
                    return Ok(supOrderLineResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSupOrderLineBySupplierOrderIdAndProdId action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/prodId", Name = "SupOrderLineByProductId")]
        public IActionResult GetSupOrderLineByProductId(int id)
        {
            try
            {
                var supOrderLine = _repository.SupplierOrderLine.GetSupOrderLineByProductId(id);
                if (supOrderLine == null)
                {
                    _logger.LogError($"supOrderLine with product id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned supOrderLine with prodduct id: {id} from database.");
                    var supOrderLineResult = _mapper.Map<SupplierOrderLineDto>(supOrderLine);
                    return Ok(supOrderLineResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSupOrderLineByProductId action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/prodId/detail", Name = "SupOrderLineByProductIdWithDetails")]
        public IActionResult GetSupOrderLineByProductIdWithDetails(int id)
        {
            try
            {
                var supOrderLine = _repository.SupplierOrderLine.GetSupOrderLineByProductIdWithDetails(id);
                if (supOrderLine == null)
                {
                    _logger.LogError($"supOrderLine with product id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned supOrderLine with prodduct id: {id} from database.");
                    var supOrderLineResult = _mapper.Map<SupplierOrderLineDetailsDto>(supOrderLine);
                    return Ok(supOrderLineResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSupOrderLineByProductId action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/sOrderId/detail", Name = "SupOrderLineBySupOrderIdWithDetails")]
        public IActionResult GetSupOrderLineBySupplierOrderIdWithDetails(int id)
        {
            try
            {
                var supOrderLine = _repository.SupplierOrderLine.GetSupOrderLineBySupplierOrderIdWithDetails(id);
                if (supOrderLine == null)
                {
                    _logger.LogError($"supOrderLine with supplier order id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned supOrderLine with supplier order id: {id} from database.");
                    var supOrderLineResult = _mapper.Map<SupplierOrderLineDetailsDto>(supOrderLine);
                    return Ok(supOrderLineResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSupOrderLineBySupplierOrderIdWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{prodId}/{sOrderId}/detail", Name = "SupOrderLineBySupOrderIdAndProdIdWithDetails")]
        public IActionResult GetSupOrderLineByProductIdAndSupOrderIdWithDetails(int prodId, int sOrderId)
        {
            try
            {
                var supOrderLine = _repository.SupplierOrderLine.GetSupOrderLineByProductIdAndSupOrderIdWithDetails(prodId,sOrderId);
                if (supOrderLine == null)
                {
                    _logger.LogError($"supOrderLine with product id: {prodId} and sOrder id: {sOrderId} hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned supOrderLine with supplier order id: {sOrderId} and product id: {prodId}, from database.");
                    var supOrderLineResult = _mapper.Map<SupplierOrderLineDetailsDto>(supOrderLine);
                    return Ok(supOrderLineResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSupOrderLineByProductIdAndSupOrderIdWithDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateSupplierOrderLine([FromBody] SupplierOrderLineForCreationDto sOrderLine)
        {
            try
            {
                if (sOrderLine == null)
                {
                    _logger.LogError("sOrderLine object sent from client is null.");
                    return BadRequest("sOrderLine object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid sOrderLine object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var sOrderLineEntity = _mapper.Map<SupplierOrderLine>(sOrderLine);

                _repository.SupplierOrderLine.CreateSupplierOrderLne(sOrderLineEntity);
                _repository.Save();

                var createdsOrderLine = _mapper.Map<SupplierOrderLineDto>(sOrderLineEntity);

                return CreatedAtRoute("SupOrderLineBySupOrderIdAndProdIdWithDetails", new { prodId = createdsOrderLine.ProductIdFk, sOrderId = createdsOrderLine.SupplierOrderIdFk }, createdsOrderLine);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateSupplierOrderLine action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{sOrderId}/{prodId}")]
        public IActionResult UpdateSupplierOrderLine(int sOrderId,int prodId, [FromBody] SupplierOrderLineForUpdateDto sOrderLine)
        {
            try
            {
                if (sOrderLine == null)
                {
                    _logger.LogError("sOrder object sent from client is null.");
                    return BadRequest("sOrder object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid sOrder object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var sOrderLineEntity = _repository.SupplierOrderLine.GetSupOrderLineBySupplierOrderIdAndProdId(sOrderId, prodId);
                if (sOrderLineEntity == null)
                {
                    _logger.LogError($"sOrder with sOrderId: {sOrderId} and prodId: {prodId}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(sOrderLine, sOrderLineEntity);

                _repository.SupplierOrderLine.UpdateSupplierOrderLine(sOrderLineEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSupplierOrderLine action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        //Still need to do delete but logic of what needs to be deleted is difficult
    }
}
