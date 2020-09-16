using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class QrCodeSeating
    {
        public int NrOfPeople { get; set; }
        public int QrCodeIdFk { get; set; }
        public int SeatingIdFk { get; set; }
        public int? OrderIdFk { get; set; }
        public int QrCodeSeatingId { get; set; }

        public virtual Order OrderIdFkNavigation { get; set; }
        public virtual QrCode QrCodeIdFkNavigation { get; set; }
        public virtual Seating SeatingIdFkNavigation { get; set; }
    }
}
