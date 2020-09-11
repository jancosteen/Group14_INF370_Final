using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class RestaurantDetailsDto
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantUrl { get; set; }
        public string RestaurantDescription { get; set; }
        public string RestaurantCoordinates { get; set; }
        public DateTime? RestaurantDateCreated { get; set; }
        public string RestaurantAddressLine1 { get; set; }
        public string ResaturantAddressLine2 { get; set; }
        public string RestaurantAddressLine3 { get; set; }
        public string RestaurantCity { get; set; }
        public string RestaurantPostalCode { get; set; }
        public string RestaurantProvince { get; set; }
        public string RestaurantCountry { get; set; }
        public int? RestaurantStatusIdFk { get; set; }

        public virtual Restaurant_StatusDto RestaurantStatusIdFkNavigation { get; set; }
        public virtual ICollection<EmployeeDto> Employee { get; set; }
        public virtual ICollection<MenuDto> Menu { get; set; }
        public virtual ICollection<Restaurant_Facility_RefDto> ResaurantFacilityRef { get; set; }
        public virtual ICollection<Restaurant_AdvertisementDto> RestaurantAdvertisement { get; set; }
        public virtual ICollection<Restaurant_ImageDto> RestaurantImage { get; set; }
        public virtual ICollection<Restaurant_Type_RefDto> RestaurantTypeReference { get; set; }
        public virtual ICollection<Seating_LayoutDto> SeatingLayout { get; set; }
        public virtual ICollection<SocialMediaDto> SocialMedia { get; set; }
        public virtual ICollection<User_CommentDto> UserComment { get; set; }
    }
}
