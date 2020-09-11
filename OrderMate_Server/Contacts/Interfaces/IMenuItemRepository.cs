using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IMenuItemRepository: IRepositoryBase<MenuItem>
    {
        IEnumerable<MenuItem> GetAllMenuItems();
        MenuItem GetMenuITemById(int menuItemId);
        MenuItem GetMenuItemWithDetails(int menuItemId);
        void CreateMenuItem(MenuItem menuItem);
        void UpdateMenuItem(MenuItem menuItem);
        void DeleteMenuItem(MenuItem menuItem);
    }
}
