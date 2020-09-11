using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class StarRating
    {
        public int StarRatingId { get; set; }
        public int StarRatingValue { get; set; }
        public int? UserCommentIdFk { get; set; }

        public virtual UserComment UserCommentIdFkNavigation { get; set; }
    }
}
