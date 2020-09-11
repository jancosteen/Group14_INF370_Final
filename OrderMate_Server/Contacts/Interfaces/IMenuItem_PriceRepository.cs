using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IMenuItem_PriceRepository: IRepositoryBase<MenuItemPrice>
    {
        IEnumerable<MenuItemPrice> GetAllMenuItemPrices();
        MenuItemPrice GetMenuITemPriceById(int menuItemPriceId);
        MenuItemPrice GetMenuITemPriceByMenuItemId(int menuItem);
        MenuItemPrice GetMenuItemPriceWithDetails(int menuItemPriceId);
        void CreateMenuItemPrice(MenuItemPrice menuItemPrice);
        void UpdateMenuItemPrice(MenuItemPrice menuItemPrice);
        void DeleteMenuItemPrice(MenuItemPrice menuItemPrice);
    }
}
