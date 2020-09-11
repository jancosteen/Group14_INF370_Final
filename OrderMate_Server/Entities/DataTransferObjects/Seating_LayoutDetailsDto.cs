using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Seating_LayoutDetailsDto
    {
        public int SeatingLayoutId { get; set; }
        public string SeatingLayoutQty { get; set; }
        public int RestaurantIdFk { get; set; }
        public int LayoutTypeIdFk { get; set; }

        public virtual Layout_TypeDto LayoutTypeIdFkNavigation { get; set; }
        public virtual RestaurantDto RestaurantIdFkNavigation { get; set; }
    }
}
