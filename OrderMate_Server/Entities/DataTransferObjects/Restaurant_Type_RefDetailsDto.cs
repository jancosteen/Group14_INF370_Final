using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Restaurant_Type_RefDetailsDto
    {
        public int RestaurantTypeIdFk { get; set; }
        public int RestaurantIdFk { get; set; }

        public virtual RestaurantDto RestaurantIdFkNavigation { get; set; }
        public virtual Restaurant_TypeDto RestaurantTypeIdFkNavigation { get; set; }
    }
}
