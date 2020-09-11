using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class RestaurantTypeReference
    {
        public int RestaurantTypeIdFk { get; set; }
        public int RestaurantIdFk { get; set; }

        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
        public virtual RestaurantType RestaurantTypeIdFkNavigation { get; set; }
    }
}
