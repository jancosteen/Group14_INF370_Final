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
    [Route("api/resFacilityRef")]
    [ApiController]
    public class Restaurant_Facility_RefController : ControllerBase
    {
        //STEPS IN COMMENTS

        //1st: Inject logger and repo service in constructor: public SupplierController(ILoggerManager logger, IRepositoryWrapper repository)
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Restaurant_Facility_RefController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        //2nd Map to a GET function
        //IActionResult - Supports variety of methods AND status codes
        [HttpGet]
        public IActionResult GetAllRestaurantFacilityRefs()
        {
            try
            {
                var restaurantFacilityRefs = _repository.Restaurant_Facility_Ref.GetAllRestaurantFacilityRefs();
                _logger.LogInfo($"Returned all restaurantFacilityRefs records from database");

                var restaurantFacilityRefsResult = _mapper.Map<IEnumerable<Restaurant_Facility_RefDto>>(restaurantFacilityRefs);

                return Ok(restaurantFacilityRefsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllRestaurantFacilityRefs() action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{resFacId}/{resId}", Name = "Restaurant_Facility_RefById")]
        public IActionResult GetRestaurant_Facility_RefById(int resFacId, int resId)
        {
            try
            {
                var restaurantFacilityRef = _repository.Restaurant_Facility_Ref.GetResaurantFacilityRefById(resFacId, resId);
                if (restaurantFacilityRef == null)
                {
                    _logger.LogError($"restaurantFacilityRefs with resFacId id: {resFacId} and resId :{resId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned restaurantFacilityRef with employee id: {resFacId} and resId :{resId} from database.");
                    var restaurantFacilityRefResult = _mapper.Map<Restaurant_Facility_RefDto>(restaurantFacilityRef);
                    return Ok(restaurantFacilityRefResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurant_Facility_RefById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{resFacId}/{resId}/detail", Name = "Restaurant_Facility_RefDetails")]
        public IActionResult GetRestaurant_Facility_RefDetails(int resFacId, int resId)
        {
            try
            {
                var restaurantFacilityRef = _repository.Restaurant_Facility_Ref.GetResaurantFacilityRefDetails(resFacId, resId);
                if (restaurantFacilityRef == null)
                {
                    _logger.LogError($"restaurantFacilityRef with resFacId id: {resFacId} and resId :{resId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned restaurantFacilityRef with resFacId id: {resFacId} and resId :{resId} from database.");
                    var restaurantFacilityRefResult = _mapper.Map<Restaurant_Facility_RefDetailsDto>(restaurantFacilityRef);
                    return Ok(restaurantFacilityRefResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurant_Facility_RefDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateRestaurant_Facility_Ref([FromBody] Restaurant_Facility_RefForCreationDto restaurantFacilityRef)
        {
            try
            {
                if (restaurantFacilityRef == null)
                {
                    _logger.LogError("restaurantFacilityRef object sent from client is null.");
                    return BadRequest("restaurantFacilityRef object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid restaurantFacilityRef object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var restaurantFacilityRefEntity = _mapper.Map<ResaurantFacilityRef>(restaurantFacilityRef);

                _repository.Restaurant_Facility_Ref.CreateResaurantFacilityRef(restaurantFacilityRefEntity);
                _repository.Save();

                var createdEmpShift = _mapper.Map<Restaurant_Facility_RefDto>(restaurantFacilityRefEntity);

                return CreatedAtRoute("Restaurant_Facility_RefDetails", new { resFacId = createdEmpShift.RestaurantFacilityIdFk, resId = createdEmpShift.RestaurantIdFk }, createdEmpShift);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateRestaurant_Facility_Ref action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{resFacId}/{resId}")]
        public IActionResult UpdateProdStockTake(int resFacId, int resId, [FromBody] Restaurant_Facility_RefForUpdateDto restaurantFacilityRef)
        {
            try
            {
                if (restaurantFacilityRef == null)
                {
                    _logger.LogError("restaurantFacilityRef object sent from client is null.");
                    return BadRequest("restaurantFacilityRef object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid restaurantFacilityRef object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var restaurantFacilityRefEntity = _repository.Restaurant_Facility_Ref.GetResaurantFacilityRefById(resFacId, resId);
                if (restaurantFacilityRefEntity == null)
                {
                    _logger.LogError($"restaurantFacilityRef with resFacId: {resFacId} and resId: {resId}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(restaurantFacilityRef, restaurantFacilityRefEntity);

                _repository.Restaurant_Facility_Ref.UpdateResaurantFacilityRef(restaurantFacilityRefEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateRestaurant_Facility_Ref action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
