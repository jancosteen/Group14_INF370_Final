using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Layout_TypeDetailsDto
    {
        public int LayoutTypeId { get; set; }
        public string LayoutType1 { get; set; }

        public virtual ICollection<Seating_LayoutDto> SeatingLayout { get; set; }
    }
}
