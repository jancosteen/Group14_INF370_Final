using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class RestaurantFacility
    {
        public RestaurantFacility()
        {
            ResaurantFacilityRef = new HashSet<ResaurantFacilityRef>();
        }

        public int RestaurantFacilityId { get; set; }
        public string RestaurantFacility1 { get; set; }

        public virtual ICollection<ResaurantFacilityRef> ResaurantFacilityRef { get; set; }
    }
}
