using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class RestaurantRestaurantImage
    {
        public int RestaurantIdFk { get; set; }
        public int RestaurantImageIdFk { get; set; }
        public int RestaurantRestaurantImageId { get; set; }

        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
        public virtual RestaurantImage RestaurantImageIdFkNavigation { get; set; }
    }
}
