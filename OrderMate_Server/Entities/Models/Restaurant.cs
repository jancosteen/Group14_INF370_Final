using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Employee = new HashSet<Employee>();
            Menu = new HashSet<Menu>();
            QrCode = new HashSet<QrCode>();
            ResaurantFacilityRef = new HashSet<ResaurantFacilityRef>();
            RestaurantAdvertisement = new HashSet<RestaurantAdvertisement>();
            RestaurantImage = new HashSet<RestaurantImage>();
            RestaurantTypeReference = new HashSet<RestaurantTypeReference>();
            SeatingLayout = new HashSet<SeatingLayout>();
            SocialMedia = new HashSet<SocialMedia>();
            UserComment = new HashSet<UserComment>();
        }

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
        public int? QrCodeIdFk { get; set; }

        public virtual RestaurantStatus RestaurantStatusIdFkNavigation { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
        public virtual ICollection<QrCode> QrCode { get; set; }
        public virtual ICollection<ResaurantFacilityRef> ResaurantFacilityRef { get; set; }
        public virtual ICollection<RestaurantAdvertisement> RestaurantAdvertisement { get; set; }
        public virtual ICollection<RestaurantImage> RestaurantImage { get; set; }
        public virtual ICollection<RestaurantTypeReference> RestaurantTypeReference { get; set; }
        public virtual ICollection<SeatingLayout> SeatingLayout { get; set; }
        public virtual ICollection<SocialMedia> SocialMedia { get; set; }
        public virtual ICollection<UserComment> UserComment { get; set; }
    }
}
