using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class MenuItemTypeDetailsDto
    {
        public int MenuItemTypeId { get; set; }
        public string MenuItemType1 { get; set; }

        public virtual ICollection<MenuItem_ItemTypeDto> ItemTypeMenuMenuItem { get; set; }
    }
}
