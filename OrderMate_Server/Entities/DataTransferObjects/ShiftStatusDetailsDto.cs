using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ShiftStatusDetailsDto
    {
        public int ShiftStatusId { get; set; }
        public string ShiftStatus1 { get; set; }

        public virtual ICollection<ShiftDto> Shift { get; set; }
    }
}
