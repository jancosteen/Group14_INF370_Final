using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SocialMedia_TypeDetailsDto
    {
        public int SocialMediaTypeId { get; set; }
        public string SocialMediaType1 { get; set; }

        public virtual ICollection<SocialMediaDto> SocialMedia { get; set; }
    }
}
