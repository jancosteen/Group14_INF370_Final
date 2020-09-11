using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class RestaurantImage
    {
        public int RestaurantImageId { get; set; }
        public string ImageDescription { get; set; }
        public byte[] ImageFile { get; set; }
        public int? RestaurantIdFk { get; set; }

        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
    }
}
