using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class RestaurantAdvertisement
    {
        public int RestaurantIdFk { get; set; }
        public int AdvertisementIdFk { get; set; }

        public virtual Advertisement AdvertisementIdFkNavigation { get; set; }
        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
    }
}
