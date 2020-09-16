using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class MenuRestaurant
    {
        public int MenuRestaurantId { get; set; }
        public int MenuIdFk { get; set; }
        public int RestaurantIdFk { get; set; }
        public int? MenuItemIdFk { get; set; }

        public virtual Menu MenuIdFkNavigation { get; set; }
        public virtual MenuItem MenuItemIdFkNavigation { get; set; }
        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
    }
}
