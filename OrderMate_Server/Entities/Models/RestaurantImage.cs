using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class RestaurantImage
    {
        public RestaurantImage()
        {
            RestaurantRestaurantImage = new HashSet<RestaurantRestaurantImage>();
        }

        public int RestaurantImageId { get; set; }
        public string ImageDescription { get; set; }
        public byte[] ImageFile { get; set; }
        public int? RestaurantIdFk { get; set; }

        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
        public virtual ICollection<RestaurantRestaurantImage> RestaurantRestaurantImage { get; set; }
    }
}
