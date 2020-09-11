using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class QrCode_SeatingDetailsDto
    {
        public int NrOfPeople { get; set; }
        public int QrCodeIdFk { get; set; }
        public int SeatingIdFk { get; set; }
        public int? OrderIdFk { get; set; }

        public virtual OrderDto OrderIdFkNavigation { get; set; }
        public virtual QrCodeDto QrCodeIdFkNavigation { get; set; }
        public virtual SeatingDto SeatingIdFkNavigation { get; set; }
    }
}
