using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Restaurant_TypeDetailsDto
    {
        public int RestaurantTypeId { get; set; }
        public string RestaurantType1 { get; set; }

        public virtual ICollection<Restaurant_Type_RefDto> RestaurantTypeReference { get; set; }
    }
}
