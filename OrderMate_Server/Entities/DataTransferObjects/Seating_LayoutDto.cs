using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Seating_LayoutDto
    {
        public int SeatingLayoutId { get; set; }
        public string SeatingLayoutQty { get; set; }
        public int RestaurantIdFk { get; set; }
        public int LayoutTypeIdFk { get; set; }
    }
}
