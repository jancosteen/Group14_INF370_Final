using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ShiftDetailsDto
    {
        public int ShiftId { get; set; }
        public DateTime ShiftStartDateTime { get; set; }
        public DateTime ShiftEndDateTime { get; set; }
        public int ShiftCapacity { get; set; }
        public string ShiftName { get; set; }
        public int? ShiftStatusIdFk { get; set; }

        public virtual ShiftStatusDto ShiftStatusIdFkNavigation { get; set; }
        public virtual ICollection<EmployeeShiftDto> EmployeeShift { get; set; }
    }
}
