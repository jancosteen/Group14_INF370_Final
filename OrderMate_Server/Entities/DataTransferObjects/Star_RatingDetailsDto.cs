using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Star_RatingDetailsDto
    {
        public int StarRatingId { get; set; }
        public int StarRatingValue { get; set; }
        public int? UserCommentIdFk { get; set; }

        public virtual User_CommentDto UserCommentIdFkNavigation { get; set; }
    }
}
