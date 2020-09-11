using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class StockTakeDetailsDto
    {
        public int StockTakeId { get; set; }
        public DateTime StockTakeDate { get; set; }

        public virtual ICollection<ProductStockTakeDto> ProductStockTake { get; set; }
    }
}
