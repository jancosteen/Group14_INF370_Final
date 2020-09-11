using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class AdvertisementDate
    {
        public int AdvertisementDateId { get; set; }
        public DateTime AdvertisementDateAcvtiveFrom { get; set; }
        public DateTime AdvertisementDateActiveTo { get; set; }
        public int? AdvertisementIdFk { get; set; }

        public virtual Advertisement AdvertisementIdFkNavigation { get; set; }
    }
}
