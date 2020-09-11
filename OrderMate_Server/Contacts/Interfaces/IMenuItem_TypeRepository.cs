using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IMenuItem_TypeRepository: IRepositoryBase<MenuItemType>
    {
        IEnumerable<MenuItemType> GetAllMenuItemTypes();
        MenuItemType GetMenuITemTypeById(int menuItemTypeId);
        MenuItemType GetMenuItemTypeWithDetails(int menuItemTypeId);
        void CreateMenuItemType(MenuItemType menuItemType);
        void UpdateMenuItemtype(MenuItemType menuItemType);
        void DeleteMenuItemType(MenuItemType menuItemType);
    }
}
