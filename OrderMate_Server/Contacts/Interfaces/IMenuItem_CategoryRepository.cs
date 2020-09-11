using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IMenuItem_CategoryRepository: IRepositoryBase<MenuItemCategory>
    {
        IEnumerable<MenuItemCategory> GetAllMenuItemCategories();
        MenuItemCategory GetMenuITemCategoryById(int menuItemCatId);
        MenuItemCategory GetMenuItemcateegoryWithDetails(int menuItemCatId);
        void CreateMenuItemCategory(MenuItemCategory menuItemCat);
        void UpdateMenuItemCategory(MenuItemCategory menuItemCat);
        void DeleteMenuItemCategory(MenuItemCategory menuItemCat);
    }
}
