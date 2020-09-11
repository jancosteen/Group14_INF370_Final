using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class WriteOffReasonDto
    {
        public int WriteOffReasonId { get; set; }
        public string WriteOffReason1 { get; set; }
        public int WrittenOffStockIdFkFk { get; set; }
        public int ProductIdFkFk { get; set; }
    }
}
