using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class Advertisement
    {
        public Advertisement()
        {
            AdvertisementDate = new HashSet<AdvertisementDate>();
            AdvertisementPrice = new HashSet<AdvertisementPrice>();
            RestaurantAdvertisement = new HashSet<RestaurantAdvertisement>();
        }

        public int AdvertisementId { get; set; }
        public string AdvertisementName { get; set; }
        public string AdvertisementDescription { get; set; }
        public byte[] AdvertisementFile { get; set; }

        public virtual ICollection<AdvertisementDate> AdvertisementDate { get; set; }
        public virtual ICollection<AdvertisementPrice> AdvertisementPrice { get; set; }
        public virtual ICollection<RestaurantAdvertisement> RestaurantAdvertisement { get; set; }
    }
}
