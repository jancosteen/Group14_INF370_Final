using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Advertisement_DateDetailsDto
    {
        public int AdvertisementDateId { get; set; }
        public DateTime AdvertisementDateAcvtiveFrom { get; set; }
        public DateTime AdvertisementDateActiveTo { get; set; }
        public int? AdvertisementIdFk { get; set; }

        public virtual AdvertisementDto AdvertisementIdFkNavigation { get; set; }
    }
}
