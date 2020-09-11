using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class RestaurantType
    {
        public RestaurantType()
        {
            RestaurantTypeReference = new HashSet<RestaurantTypeReference>();
        }

        public int RestaurantTypeId { get; set; }
        public string RestaurantType1 { get; set; }

        public virtual ICollection<RestaurantTypeReference> RestaurantTypeReference { get; set; }
    }
}
