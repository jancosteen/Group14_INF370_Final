using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class OrderLine
    {
        public int OrderLineId { get; set; }
        public int ItemQty { get; set; }
        public string ItemComments { get; set; }
        public int? SpecialIdFk { get; set; }
        public int? MenuItemIdFk { get; set; }
        public int? OrderIdFk { get; set; }
        public string UserIdFk { get; set; }

        public virtual MenuItem MenuItemIdFkNavigation { get; set; }
        public virtual Order OrderIdFkNavigation { get; set; }
        public virtual Special SpecialIdFkNavigation { get; set; }
        public virtual User UserIdFkNavigation { get; set; }
    }
}
