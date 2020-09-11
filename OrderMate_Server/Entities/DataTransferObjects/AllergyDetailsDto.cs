using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class AllergyDetailsDto
    {
        public int AllergyId { get; set; }
        public string Allergy1 { get; set; }

        public virtual ICollection<MenuItem_AllergyDto> MenuItemAllergy { get; set; }
    }
}
