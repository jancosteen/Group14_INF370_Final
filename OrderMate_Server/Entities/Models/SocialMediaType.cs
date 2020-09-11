using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class SocialMediaType
    {
        public SocialMediaType()
        {
            SocialMedia = new HashSet<SocialMedia>();
        }

        public int SocialMediaTypeId { get; set; }
        public string SocialMediaType1 { get; set; }

        public virtual ICollection<SocialMedia> SocialMedia { get; set; }
    }
}
