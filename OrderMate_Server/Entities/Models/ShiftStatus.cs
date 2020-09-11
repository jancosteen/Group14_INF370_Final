using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class ShiftStatus
    {
        public ShiftStatus()
        {
            Shift = new HashSet<Shift>();
        }

        public int ShiftStatusId { get; set; }
        public string ShiftStatus1 { get; set; }

        public virtual ICollection<Shift> Shift { get; set; }
    }
}
