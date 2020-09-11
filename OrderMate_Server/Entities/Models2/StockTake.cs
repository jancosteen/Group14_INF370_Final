using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class StockTake
    {
        public StockTake()
        {
            ProductStockTake = new HashSet<ProductStockTake>();
        }

        public int StockTakeId { get; set; }
        public DateTime StockTakeDate { get; set; }

        public virtual ICollection<ProductStockTake> ProductStockTake { get; set; }
    }
}
