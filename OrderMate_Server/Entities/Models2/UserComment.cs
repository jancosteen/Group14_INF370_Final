using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class UserComment
    {
        public UserComment()
        {
            StarRating = new HashSet<StarRating>();
            TableSeating = new HashSet<TableSeating>();
        }

        public int UserCommentId { get; set; }
        public string UserComment1 { get; set; }
        public DateTime UserCommentDateCreated { get; set; }
        public int? RestaurantIdFk { get; set; }

        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
        public virtual ICollection<StarRating> StarRating { get; set; }
        public virtual ICollection<TableSeating> TableSeating { get; set; }
    }
}
