using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class LayoutType
    {
        public LayoutType()
        {
            SeatingLayout = new HashSet<SeatingLayout>();
        }

        public int LayoutTypeId { get; set; }
        public string LayoutType1 { get; set; }

        public virtual ICollection<SeatingLayout> SeatingLayout { get; set; }
    }
}
