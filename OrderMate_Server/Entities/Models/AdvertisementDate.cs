using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class AdvertisementDate
    {
        public AdvertisementDate()
        {
            Advertisement = new HashSet<Advertisement>();
        }

        public int AdvertisementDateId { get; set; }
        public DateTime AdvertisementDateAcvtiveFrom { get; set; }
        public DateTime AdvertisementDateActiveTo { get; set; }

        public virtual ICollection<Advertisement> Advertisement { get; set; }
    }
}
