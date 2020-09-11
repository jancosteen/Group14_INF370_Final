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
    [Route("api/restAdv")]
    [ApiController]
    public class Restaurant_AdvertisementController : ControllerBase
    {
        //STEPS IN COMMENTS

        //1st: Inject logger and repo service in constructor: public SupplierController(ILoggerManager logger, IRepositoryWrapper repository)
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public Restaurant_AdvertisementController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        //2nd Map to a GET function
        //IActionResult - Supports variety of methods AND status codes
        [HttpGet]
        public IActionResult GetAllRestaurantAdvertisements()
        {
            try
            {
                var restaurantAdvertisements = _repository.Restaurant_Advertisement.GetAllRestaurantAdvertisements();
                _logger.LogInfo($"Returned all restaurantAdvertisements records from database");

                var restaurantAdvertisementsResult = _mapper.Map<IEnumerable<Restaurant_AdvertisementDto>>(restaurantAdvertisements);

                return Ok(restaurantAdvertisementsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllRestaurantAdvertisements() action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{resId}/{advId}", Name = "Restaurant_AdvertisementById")]
        public IActionResult GetRestaurant_AdvertisementById(int resId, int advId)
        {
            try
            {
                var restaurantAdvertisement = _repository.Restaurant_Advertisement.GetRestaurantAdvertisementById(resId, advId);
                if (restaurantAdvertisement == null)
                {
                    _logger.LogError($"restaurantAdvertisements with resId id: {resId} and advId :{advId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned restaurantAdvertisement with employee id: {resId} and advId :{advId} from database.");
                    var restaurantAdvertisementResult = _mapper.Map<Restaurant_AdvertisementDto>(restaurantAdvertisement);
                    return Ok(restaurantAdvertisementResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurant_AdvertisementById action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{resId}/{advId}/detail", Name = "Restaurant_AdvertisementDetails")]
        public IActionResult GetRestaurant_AdvertisementDetails(int resId, int advId)
        {
            try
            {
                var restaurantAdvertisement = _repository.Restaurant_Advertisement.GetRestaurantAdvertisementDetails(resId, advId);
                if (restaurantAdvertisement == null)
                {
                    _logger.LogError($"restaurantAdvertisement with resId id: {resId} and advId :{advId}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned restaurantAdvertisement with resId id: {resId} and advId :{advId} from database.");
                    var restaurantAdvertisementResult = _mapper.Map<Restaurant_AdvertisementDetailsDto>(restaurantAdvertisement);
                    return Ok(restaurantAdvertisementResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetRestaurant_AdvertisementDetails action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateRestaurant_Advertisement([FromBody] Restaurant_AdvertisementForCreationDto restaurantAdvertisement)
        {
            try
            {
                if (restaurantAdvertisement == null)
                {
                    _logger.LogError("restaurantAdvertisement object sent from client is null.");
                    return BadRequest("restaurantAdvertisement object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid restaurantAdvertisement object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var restaurantAdvertisementEntity = _mapper.Map<RestaurantAdvertisement>(restaurantAdvertisement);

                _repository.Restaurant_Advertisement.CreateRestaurantAdvertisement(restaurantAdvertisementEntity);
                _repository.Save();

                var createdEmpShift = _mapper.Map<Restaurant_AdvertisementDto>(restaurantAdvertisementEntity);

                return CreatedAtRoute("Restaurant_AdvertisementDetails", new { resId = createdEmpShift.RestaurantIdFk, advId = createdEmpShift.AdvertisementIdFk }, createdEmpShift);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateRestaurant_Advertisement action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{resId}/{advId}")]
        public IActionResult UpdateProdStockTake(int resId, int advId, [FromBody] Restaurant_AdvertisementForUpdateDto restaurantAdvertisement)
        {
            try
            {
                if (restaurantAdvertisement == null)
                {
                    _logger.LogError("restaurantAdvertisement object sent from client is null.");
                    return BadRequest("restaurantAdvertisement object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid restaurantAdvertisement object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var restaurantAdvertisementEntity = _repository.Restaurant_Advertisement.GetRestaurantAdvertisementById(resId, advId);
                if (restaurantAdvertisementEntity == null)
                {
                    _logger.LogError($"restaurantAdvertisement with resId: {resId} and advId: {advId}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(restaurantAdvertisement, restaurantAdvertisementEntity);

                _repository.Restaurant_Advertisement.UpdateRestaurantAdvertisement(restaurantAdvertisementEntity);
                _repository.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateRestaurant_Advertisement action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
