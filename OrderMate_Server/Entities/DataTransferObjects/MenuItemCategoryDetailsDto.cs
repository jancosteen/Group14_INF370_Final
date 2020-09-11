using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class MenuItemCategoryDetailsDto
    {
        public int MenuItemCategoryId { get; set; }
        public string MenuItemCategory1 { get; set; }

        public virtual ICollection<MenuItemDto> MenuItem { get; set; }
    }
}
