using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Restaurant_ImageDto
    {
        public int RestaurantImageId { get; set; }
        public string ImageDescription { get; set; }
        public byte[] ImageFile { get; set; }
        public int? RestaurantIdFk { get; set; }
    }
}
