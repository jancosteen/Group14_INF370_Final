using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class ResaurantFacilityRef
    {
        public int RestaurantFacilityIdFk { get; set; }
        public int RestaurantIdFk { get; set; }

        public virtual RestaurantFacility RestaurantFacilityIdFkNavigation { get; set; }
        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
    }
}
