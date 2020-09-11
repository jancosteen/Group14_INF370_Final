using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Restaurant_FacilityDetailsDto
    {
        public int RestaurantFacilityId { get; set; }
        public string RestaurantFacility1 { get; set; }

        public virtual ICollection<Restaurant_Facility_RefDto> ResaurantFacilityRef { get; set; }
    }
}
