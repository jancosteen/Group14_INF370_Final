using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class MenuItemRepository: RepositoryBase<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateMenuItem(MenuItem menuItem)
        {
            Create(menuItem);
        }

        public void DeleteMenuItem(MenuItem menuItem)
        {
            Delete(menuItem);
        }

        public IEnumerable<MenuItem> GetAllMenuItems()
        {
            return FindAll()
                .OrderBy(m => m.MenuItemName)
                .ToList();
        }

        public MenuItem GetMenuITemById(int menuItemId)
        {
            return FindByCondition(m => m.MenuItemId.Equals(menuItemId))
                .FirstOrDefault();
        }

        public MenuItem GetMenuItemWithDetails(int menuItemId)
        {
            return FindByCondition(m => m.MenuItemId.Equals(menuItemId))
                .Include(m => m.ItemTypeMenuMenuItem)
                .Include(m => m.MenuIdFkNavigation)
                .Include(m => m.MenuItemAllergy)
                .Include(m => m.MenuItemCategoryIdFkNavigation)
                .Include(m => m.MenuItemSpecial)
                //.Include(m => m.OrderLine)
                .FirstOrDefault();
        }

        public void UpdateMenuItem(MenuItem menuItem)
        {
            Update(menuItem);
        }
    }
}
