using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Advertisement_PriceForCreationDto
    {
        public double AdvertismentPrice { get; set; }
        public DateTime AdvertisementPriceDateUpdated { get; set; }
        public int? AdvertisementIdFk { get; set; }
    }
}
