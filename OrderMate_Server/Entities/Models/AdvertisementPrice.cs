using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class AdvertisementPrice
    {
        public AdvertisementPrice()
        {
            Advertisement = new HashSet<Advertisement>();
        }

        public int AdvertisementPriceId { get; set; }
        public double AdvertismentPrice { get; set; }
        public DateTime AdvertisementPriceDateUpdated { get; set; }

        public virtual ICollection<Advertisement> Advertisement { get; set; }
    }
}
