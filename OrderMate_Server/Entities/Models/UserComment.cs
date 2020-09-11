using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class UserComment
    {
        public UserComment()
        {
            StarRating = new HashSet<StarRating>();
        }

        public int UserCommentId { get; set; }
        public string UserComment1 { get; set; }
        public DateTime UserCommentDateCreated { get; set; }
        public int? RestaurantIdFk { get; set; }

        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
        public virtual ICollection<StarRating> StarRating { get; set; }
    }
}
