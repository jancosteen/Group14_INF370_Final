using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProductStockTakeDetailsDto
    {
        public int EmployeeIdFk { get; set; }
        public int ProductIdFk { get; set; }
        public int ProductStockTakeQty { get; set; }
        public int? StockTakeIdFk { get; set; }

        public virtual EmployeeDto EmployeeIdFkNavigation { get; set; }
        public virtual ProductDto ProductIdFkNavigation { get; set; }
        public virtual StockTakeDto StockTakeIdFkNavigation { get; set; }
    }
}
