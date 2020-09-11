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
    [Route("api/resTypeRef")]
    [ApiController]
    public class Restaurant_Type_ReferenceController : ControllerBase
    {
        //STEPS IN COMMENTS

        //1st: Inject logger and repo service in constructor: public SupplierController(ILoggerManager logger, IRepositoryWrapper repository)
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Restaurant_Type_ReferenceController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        //2nd Map to a GET function
        //IActionResult - Supports variety of methods AND status codes
        [HttpGet]
        public IActionResult GetAllResTypeRefs()
        {
            try
            {
                var resTypeRefs = _repository.Restaurant_Type_Ref.GetAllRestaurantTypeReferences();
                _logger.LogInfo($"Returned all resTypeRefs records from database");

                var resTypeRefsResult = _mapper.Map<IEnumerable<Restaurant_Type_RefDto>>(resTypeRefs);

                return Ok(resTypeRefsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllResTypeRefs() action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{resFacId}/{resId}", Name = "Restaurant_Type_RefById")]
        public IActionResult GetRestaurant_Type_RefById(int resFacId, int resId)
        {
            try
            {
                var resTypeRef = _repository.Restaurant_Type_Ref.GetRestaurantTypeReferenceById(resFacId, resId);
                if (resTypeRef == null)
                {
                    _logger.LogError($"resTypeRefs with resFacId id: {resFacId} and resId :{resId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned resTypeRef with employee id: {resFacId} and resId :{resId} from database.");
                    var resTypeRefResult = _mapper.Map<Restaurant_Type_RefDto>(resTypeRef);
                    return Ok(resTypeRefResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurant_Type_RefById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{resFacId}/{resId}/detail", Name = "Restaurant_Type_RefDetails")]
        public IActionResult GetRestaurant_Type_RefDetails(int resFacId, int resId)
        {
            try
            {
                var resTypeRef = _repository.Restaurant_Type_Ref.GetRestaurantTypeReferenceDetails(resFacId, resId);
                if (resTypeRef == null)
                {
                    _logger.LogError($"resTypeRef with resFacId id: {resFacId} and resId :{resId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned resTypeRef with resFacId id: {resFacId} and resId :{resId} from database.");
                    var resTypeRefResult = _mapper.Map<Restaurant_Type_RefDetailsDto>(resTypeRef);
                    return Ok(resTypeRefResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurant_Type_RefDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateRestaurant_Type_Ref([FromBody] Restaurant_Type_RefForCreationDto resTypeRef)
        {
            try
            {
                if (resTypeRef == null)
                {
                    _logger.LogError("resTypeRef object sent from client is null.");
                    return BadRequest("resTypeRef object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid resTypeRef object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var resTypeRefEntity = _mapper.Map<RestaurantTypeReference>(resTypeRef);

                _repository.Restaurant_Type_Ref.CreateRestaurantTypeReference(resTypeRefEntity);
                _repository.Save();

                var createdEmpShift = _mapper.Map<Restaurant_Type_RefDto>(resTypeRefEntity);

                return CreatedAtRoute("Restaurant_Type_RefDetails", new { resFacId = createdEmpShift.RestaurantTypeIdFk, resId = createdEmpShift.RestaurantIdFk }, createdEmpShift);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateRestaurant_Type_Ref action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{resFacId}/{resId}")]
        public IActionResult UpdateProdStockTake(int resFacId, int resId, [FromBody] Restaurant_Type_RefForUpdateDto resTypeRef)
        {
            try
            {
                if (resTypeRef == null)
                {
                    _logger.LogError("resTypeRef object sent from client is null.");
                    return BadRequest("resTypeRef object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid resTypeRef object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var resTypeRefEntity = _repository.Restaurant_Type_Ref.GetRestaurantTypeReferenceById(resFacId, resId);
                if (resTypeRefEntity == null)
                {
                    _logger.LogError($"resTypeRef with resFacId: {resFacId} and resId: {resId}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(resTypeRef, resTypeRefEntity);

                _repository.Restaurant_Type_Ref.UpdateRestaurantTypeReference(resTypeRefEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateRestaurant_Type_Ref action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
