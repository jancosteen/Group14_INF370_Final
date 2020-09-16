using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class RestaurantTypeReference
    {
        public int RestaurantTypeIdFk { get; set; }
        public int RestaurantIdFk { get; set; }
        public int RestaurantTypeRefId { get; set; }

        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
        public virtual RestaurantType RestaurantTypeIdFkNavigation { get; set; }
    }
}
