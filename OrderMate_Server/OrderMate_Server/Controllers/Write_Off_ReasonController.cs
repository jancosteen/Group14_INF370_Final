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
    [Route("api/writeOffReason")]
    [ApiController]
    public class Write_Off_ReasonController : ControllerBase
    {
        //STEPS IN COMMENTS

        //1st: Inject logger and repo service in constructor: public SupplierController(ILoggerManager logger, IRepositoryWrapper repository)
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Write_Off_ReasonController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        //2nd Map to a GET function
        //IActionResult - Supports variety of methods AND status codes
        [HttpGet]
        public IActionResult GetAllWriteOffReasons()
        {
            try
            {
                var prodWOR = _repository.Write_Off_Reason.GetAllWriteOffReasons();
                _logger.LogInfo($"Returned all  written off reasons records from database");

                var prodWORResult = _mapper.Map<IEnumerable<WriteOffReasonDto>>(prodWOR);

                return Ok(prodWORResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllWriteOffReasons() action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{woStockId}/{prodId}", Name = "WriteOffReasonById")]
        public IActionResult GetWriteOffReasonById(int woStockId, int prodId)
        {
            try
            {
                var prodWoR = _repository.Write_Off_Reason.GetWriteOffReasonById(woStockId, prodId);
                if (prodWoR == null)
                {
                    _logger.LogError($"Write Off Reason with writeOfStock id: {woStockId} and prodId :{prodId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned prodWoR with writeOffStock id: {woStockId} and prodId :{prodId} from database.");
                    var prodWoRResult = _mapper.Map<WriteOffReasonDto>(prodWoR);
                    return Ok(prodWoRResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetWriteOffReasonById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{woStockId}/{prodId}/detail", Name = "WriteOffReasonDetails")]
        public IActionResult GetWriteOffReasonDetails(int woStockId, int prodId)
        {
            try
            {
                var prodWoR = _repository.Write_Off_Reason.GetWriteOffReasonDetails(woStockId, prodId);
                if (prodWoR == null)
                {
                    _logger.LogError($"Write Off Reason with writeOfStock id: {woStockId} and prodId :{prodId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned prodWoR with writeOffStock id: {woStockId} and prodId :{prodId} from database.");
                    var prodWoRResult = _mapper.Map<WriteOffReasonDetailsDto>(prodWoR);
                    return Ok(prodWoRResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetWriteOffReasonDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateWriteOffReason([FromBody] WriteOffReasonForCreationDto writeOffReason)
        {
            try
            {
                if (writeOffReason == null)
                {
                    _logger.LogError("writeOffReason object sent from client is null.");
                    return BadRequest("writeOffReason object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid writeOffReason object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var writeOffReasonEntity = _mapper.Map<WriteOffReason>(writeOffReason);

                _repository.Write_Off_Reason.CreateWriteOffReason(writeOffReasonEntity);
                _repository.Save();

                var createdWriteOffReason = _mapper.Map<WriteOffReasonDto>(writeOffReasonEntity);

                return CreatedAtRoute("WriteOffReasonDetails", new { woStockId = createdWriteOffReason.WrittenOffStockIdFkFk, prodId = createdWriteOffReason.ProductIdFkFk }, createdWriteOffReason);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateWriteOffReason action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
