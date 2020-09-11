using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IMenuItem_ItemTypeRepository: IRepositoryBase<ItemTypeMenuMenuItem>
    {
        IEnumerable<ItemTypeMenuMenuItem> GetAllMenuItemItemTypes();
        ItemTypeMenuMenuItem GetMenuItemItemTypeById(int menuItemTypeId, int menuItemId);
        ItemTypeMenuMenuItem GetMenuItemItemTypeWithDetails(int menuItemTypeId, int menuItemId);
        void CreateMenuItemItemType(ItemTypeMenuMenuItem menuItemItemType);
        void UpdateMenuItemItemType(ItemTypeMenuMenuItem menuItemItemType);
        void DeleteMenuItemItemType(ItemTypeMenuMenuItem menuItemItemType);
    }
}
