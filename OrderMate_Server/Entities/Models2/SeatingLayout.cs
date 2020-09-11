using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class SeatingLayout
    {
        public int SeatingLayoutId { get; set; }
        public string SeatingLayoutQty { get; set; }
        public int RestaurantIdFk { get; set; }
        public int LayoutTypeIdFk { get; set; }

        public virtual LayoutType LayoutTypeIdFkNavigation { get; set; }
        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
    }
}
