using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class EmployeeShiftForUpdateDto
    {
        public int ShiftIdFk { get; set; }
        public int EmployeeIdFk { get; set; }
    }
}
