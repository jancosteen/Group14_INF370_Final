using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class QrCode
    {
        public QrCode()
        {
            QrCodeSeating = new HashSet<QrCodeSeating>();
        }

        public int QrCodeId { get; set; }
        public int? RestaurantIdFk { get; set; }

        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
        public virtual ICollection<QrCodeSeating> QrCodeSeating { get; set; }
    }
}
