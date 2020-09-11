using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Star_RatingForUpdateDto
    {
        public int StarRatingValue { get; set; }
        public int? UserCommentIdFk { get; set; }
    }
}
