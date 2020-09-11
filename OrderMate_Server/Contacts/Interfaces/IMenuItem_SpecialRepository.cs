using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IMenuItem_SpecialRepository: IRepositoryBase<MenuItemSpecial>
    {
        IEnumerable<MenuItemSpecial> GetAllMenuItemSpecials();
        MenuItemSpecial GetMenuItemSpecialById(int specialId, int menuItemId);
        MenuItemSpecial GetMenuItemSpecialWithDetails(int specialId, int menuItemId);
        void CreateMenuItemSpecial(MenuItemSpecial menuItemSpecial);
        void UpdateMenuItemSpecial(MenuItemSpecial menuItemSpecial);
        void DeleteMenuItemSpecial(MenuItemSpecial menuItemSpecial);
    }
}
