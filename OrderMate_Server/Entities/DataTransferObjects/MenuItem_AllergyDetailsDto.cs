using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class MenuItem_AllergyDetailsDto
    {
        public int MenuItemIdFk { get; set; }
        public int AllergyIdFk { get; set; }

        public virtual AllergyDto AllergyIdFkNavigation { get; set; }
        public virtual MenuItemDto MenuItemIdFkNavigation { get; set; }
    }
}
