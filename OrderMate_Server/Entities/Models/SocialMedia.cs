using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public string SocialMediaAddress { get; set; }
        public int? RestaurantIdFk { get; set; }
        public int SocialMediaTypeIdFk { get; set; }

        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
        public virtual SocialMediaType SocialMediaTypeIdFkNavigation { get; set; }
    }
}
