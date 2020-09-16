using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class UserImage
    {
        public UserImage()
        {
            UserUserImage = new HashSet<UserUserImage>();
        }

        public int UserImageId { get; set; }
        public byte[] ImageFile { get; set; }

        public virtual ICollection<UserUserImage> UserUserImage { get; set; }
    }
}
