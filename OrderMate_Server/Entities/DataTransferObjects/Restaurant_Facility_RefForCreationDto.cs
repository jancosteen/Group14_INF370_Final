using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Restaurant_Facility_RefForCreationDto
    {
        public int RestaurantFacilityIdFk { get; set; }
        public int RestaurantIdFk { get; set; }
    }
}
