using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SpecialForUpdateDto
    {
        public DateTime SpecialStartDate { get; set; }
        public DateTime SpecialEndDate { get; set; }
        public string SpecialName { get; set; }
        public string SpecialDescription { get; set; }
    }
}
