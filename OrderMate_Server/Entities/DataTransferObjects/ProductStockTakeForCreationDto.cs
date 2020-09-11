using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProductStockTakeForCreationDto
    {
        public int EmployeeIdFk { get; set; }
        public int ProductIdFk { get; set; }
        public int ProductStockTakeQty { get; set; }
        public int? StockTakeIdFk { get; set; }
    }
}
