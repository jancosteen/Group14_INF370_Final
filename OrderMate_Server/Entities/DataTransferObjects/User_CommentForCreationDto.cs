using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class User_CommentForCreationDto
    {
        public string UserComment1 { get; set; }
        public DateTime UserCommentDateCreated { get; set; }
        public int? RestaurantIdFk { get; set; }
    }
}
