using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class SocialMedia
    {
        public SocialMedia()
        {
            Restaurant = new HashSet<Restaurant>();
        }

        public int SocialMediaId { get; set; }
        public string SocialMediaAddress { get; set; }
        public int SocialMediaTypeIdFk { get; set; }

        public virtual SocialMediaType SocialMediaTypeIdFkNavigation { get; set; }
        public virtual ICollection<Restaurant> Restaurant { get; set; }
    }
}
