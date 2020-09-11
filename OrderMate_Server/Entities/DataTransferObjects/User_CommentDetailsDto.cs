using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class User_CommentDetailsDto
    {
        public int UserCommentId { get; set; }
        public string UserComment1 { get; set; }
        public DateTime UserCommentDateCreated { get; set; }
        public int? RestaurantIdFk { get; set; }

        public virtual RestaurantDto RestaurantIdFkNavigation { get; set; }
        public virtual ICollection<Star_RatingDto> StarRating { get; set; }
    }
}
