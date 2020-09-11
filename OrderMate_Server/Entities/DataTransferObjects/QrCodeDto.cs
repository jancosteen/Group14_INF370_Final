using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class QrCodeDto
    {
        public int QrCodeId { get; set; }
        public int? RestaurantIdFk { get; set; }
    }
}
