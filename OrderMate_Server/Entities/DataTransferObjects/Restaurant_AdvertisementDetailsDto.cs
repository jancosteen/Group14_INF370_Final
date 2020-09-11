using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Restaurant_AdvertisementDetailsDto
    {
        public int RestaurantIdFk { get; set; }
        public int AdvertisementIdFk { get; set; }

        public virtual AdvertisementDto AdvertisementIdFkNavigation { get; set; }
        public virtual RestaurantDto RestaurantIdFkNavigation { get; set; }
    }
}
