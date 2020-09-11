using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class AdvertisementPrice
    {
        public int AdvertisementPriceId { get; set; }
        public double AdvertismentPrice { get; set; }
        public DateTime AdvertisementPriceDateUpdated { get; set; }
        public int? AdvertisementIdFk { get; set; }

        public virtual Advertisement AdvertisementIdFkNavigation { get; set; }
    }
}
