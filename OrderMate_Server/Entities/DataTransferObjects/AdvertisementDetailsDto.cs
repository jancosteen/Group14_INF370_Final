using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class AdvertisementDetailsDto
    {
        public int AdvertisementId { get; set; }
        public string AdvertisementName { get; set; }
        public string AdvertisementDescription { get; set; }
        public byte[] AdvertisementFile { get; set; }

        public virtual ICollection<Advertisement_DateDto> AdvertisementDate { get; set; }
        public virtual ICollection<Advertisement_PriceDto> AdvertisementPrice { get; set; }
        public virtual ICollection<Restaurant_AdvertisementDto> RestaurantAdvertisement { get; set; }
    }
}
