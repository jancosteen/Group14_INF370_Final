using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Advertisement
    {
        public Advertisement()
        {
            RestaurantAdvertisement = new HashSet<RestaurantAdvertisement>();
        }

        public int AdvertisementId { get; set; }
        public string AdvertisementName { get; set; }
        public string AdvertisementDescription { get; set; }
        public byte[] AdvertisementFile { get; set; }
        public int? AdvertisementDateIdFk { get; set; }
        public int? AdvertisementPriceIdFk { get; set; }

        public virtual AdvertisementDate AdvertisementDateIdFkNavigation { get; set; }
        public virtual AdvertisementPrice AdvertisementPriceIdFkNavigation { get; set; }
        public virtual ICollection<RestaurantAdvertisement> RestaurantAdvertisement { get; set; }
    }
}
