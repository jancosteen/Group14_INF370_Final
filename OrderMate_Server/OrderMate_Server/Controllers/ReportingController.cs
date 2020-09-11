using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using Contacts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace OrderMate_Server.Controllers
{
    [Route("api/reporting")]
    [ApiController]
    public class ReportingController : ControllerBase
    {
        private ILoggerManager _logger;
        //private IRepositoryWrapper _repository;
        private IMapper _mapper;


        protected OrderMateDbFinalContext RepositoryContext { get; set; }

        public ReportingController(OrderMateDbFinalContext repositoryContext, ILoggerManager logger, IMapper mapper)
        {
            this.RepositoryContext = repositoryContext;
            _logger = logger;            
            _mapper = mapper;
        }
        

        [HttpGet("salesByMenuItem/{menuItemId}/{Datefrom}/{DateTo}", Name = "SalesByMenuItem")]
        public IActionResult GetSalesByMenuItemReport(int menuItemId, DateTime Datefrom, DateTime DateTo)
        {
            try
            {
                var results = RepositoryContext.SalesByMenuItemReport.FromSqlRaw("EXEC dbo.SP_SALES_BY_MENUITEM @MenuItemId = {0}, @OrderDateFrom = {1}, @OrdeDateTo = {2}", menuItemId, Datefrom, DateTo);
                _logger.LogInfo($"Returned SalesByMenutemResults from db.");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetSalesByMenuItemReport action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }           
        }

        [HttpGet("salesRestaurant/{restaurantId}/{orderDateFrom}/{ordeDateTo}", Name = "SalesByRestaurant")]
        public IActionResult GetSalesByRestaurantReport(int restaurantId, DateTime orderDateFrom, DateTime ordeDateTo)
        {
            try
            {
                var results = RepositoryContext.SalesByRestaurantReport.FromSqlRaw("EXEC dbo.SP_SALES_BY_RESTAURANT @RestaurantId = {0}, @OrderDateFrom = {1}, @OrdeDateTo = {2}", restaurantId, orderDateFrom, ordeDateTo);
                _logger.LogInfo($"Returned SalesByRestaurantResults from db.");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetSalesByRestaurantReport action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("peakHours/{dateFrom}/{dateTo}/{restaurantId}", Name = "PeakHoursReport")]
        public IActionResult GetPeakHourReport(DateTime dateFrom, DateTime dateTo, int restaurantId)
        {
            try
            {
                var results = RepositoryContext.PeakHourReport.FromSqlRaw("EXEC dbo.SP_SEATING_COUNT_BY_HOUR @DateFrom = {0}, @DateTo = {1}, @RestaurantId = {2}", dateFrom, dateTo, restaurantId);
                _logger.LogInfo($"Returned PeakHourResults from db.");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetPeakHourReport action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("supplierOrder/{orderDateFrom}/{orderDateTo}/{supplierId}", Name = "supplierOrdersReport")]
        public IActionResult GetSupplierOrderReport(DateTime orderDateFrom, DateTime orderDateTo, int supplierId)
        {
            try
            {
                var results = RepositoryContext.SupplierOrderReport.FromSqlRaw("EXEC dbo.SP_SUPPLIER_ORDER_REPORT @OrderDateFrom = {0}, @OrderDateTo = {1}, @SupplierId = {2}", orderDateFrom, orderDateTo, supplierId);
                _logger.LogInfo($"Returned SupplierOrdersReport from db.");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went work inside the GetSupplierOrderReport action: {ex.InnerException.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
