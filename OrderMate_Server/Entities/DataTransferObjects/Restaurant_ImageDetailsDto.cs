using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Restaurant_ImageDetailsDto
    {
        public int RestaurantImageId { get; set; }
        public string ImageDescription { get; set; }
        public byte[] ImageFile { get; set; }
        public int? RestaurantIdFk { get; set; }

        public virtual RestaurantDto RestaurantIdFkNavigation { get; set; }
    }
}
