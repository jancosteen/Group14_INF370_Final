using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Shift
    {
        public Shift()
        {
            EmployeeShift = new HashSet<EmployeeShift>();
        }

        public int ShiftId { get; set; }
        public DateTime ShiftStartDateTime { get; set; }
        public DateTime ShiftEndDateTime { get; set; }
        public int ShiftCapacity { get; set; }
        public string ShiftName { get; set; }
        public int? ShiftStatusIdFk { get; set; }

        public virtual ShiftStatus ShiftStatusIdFkNavigation { get; set; }
        public virtual ICollection<EmployeeShift> EmployeeShift { get; set; }
    }
}
