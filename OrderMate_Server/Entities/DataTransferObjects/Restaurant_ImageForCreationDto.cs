using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Restaurant_ImageForCreationDto
    {
        public string ImageDescription { get; set; }
        public byte[] ImageFile { get; set; }
        public int? RestaurantIdFk { get; set; }
    }
}
