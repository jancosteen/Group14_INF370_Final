using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class QrCode_SeatingForUpdateDto
    {
        public int NrOfPeople { get; set; }
        public int QrCodeIdFk { get; set; }
        public int SeatingIdFk { get; set; }
        public int? OrderIdFk { get; set; }
    }
}
