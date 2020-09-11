using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class ProductStockTake
    {
        public int? EmployeeIdFk { get; set; }
        public int ProductIdFk { get; set; }
        public int ProductStockTakeQty { get; set; }
        public int StockTakeIdFk { get; set; }

        public virtual Employee EmployeeIdFkNavigation { get; set; }
        public virtual Product ProductIdFkNavigation { get; set; }
        public virtual StockTake StockTakeIdFkNavigation { get; set; }
    }
}
