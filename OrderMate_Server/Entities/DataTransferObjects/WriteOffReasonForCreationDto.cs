using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class WriteOffReasonForCreationDto
    {
        public string WriteOffReason1 { get; set; }
        public int WrittenOffStockIdFkFk { get; set; }
        public int ProductIdFkFk { get; set; }
    }
}
