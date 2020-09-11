using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Restaurant_Facility_RefDetailsDto
    {
        public int RestaurantFacilityIdFk { get; set; }
        public int RestaurantIdFk { get; set; }

        public virtual Restaurant_FacilityDto RestaurantFacilityIdFkNavigation { get; set; }
        public virtual RestaurantDto RestaurantIdFkNavigation { get; set; }
    }
}
