using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class MenuItemSpecial
    {
        public int SpecialIdFk { get; set; }
        public int MenuItemIdFk { get; set; }

        public virtual MenuItem MenuItemIdFkNavigation { get; set; }
        public virtual Special SpecialIdFkNavigation { get; set; }
    }
}
