using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class QrCode
    {
        public int QrCodeId { get; set; }
        public int? RestaurantIdFk { get; set; }

        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
        public virtual QrCodeSeating QrCodeSeating { get; set; }
    }
}
