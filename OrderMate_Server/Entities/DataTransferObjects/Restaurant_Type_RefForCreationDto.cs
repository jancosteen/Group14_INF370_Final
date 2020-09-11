using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Restaurant_Type_RefForCreationDto
    {
        public int RestaurantTypeIdFk { get; set; }
        public int RestaurantIdFk { get; set; }
    }
}
