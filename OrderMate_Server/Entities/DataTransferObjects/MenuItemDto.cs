using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class MenuItemDto
    {
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public int? MenuIdFk { get; set; }
        public int? MenuItemCategoryIdFk { get; set; }
    }
}
