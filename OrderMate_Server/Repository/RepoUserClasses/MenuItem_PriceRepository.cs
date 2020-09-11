using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class MenuItem_PriceRepository: RepositoryBase<MenuItemPrice>, IMenuItem_PriceRepository
    {
        public MenuItem_PriceRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateMenuItemPrice(MenuItemPrice menuItemPrice)
        {
            Create(menuItemPrice);
        }

        public void DeleteMenuItemPrice(MenuItemPrice menuItemPrice)
        {
            Delete(menuItemPrice);
        }

        public IEnumerable<MenuItemPrice> GetAllMenuItemPrices()
        {
            return FindAll()
                .OrderBy(mip => mip.MenuItemIdFk)
                .ToList();
        }

        public MenuItemPrice GetMenuITemPriceById(int menuItemPriceId)
        {
            return FindByCondition(mip => mip.MenuItemPriceId.Equals(menuItemPriceId))
                .FirstOrDefault();
        }

        public MenuItemPrice GetMenuITemPriceByMenuItemId(int menuItem)
        {
            return FindByCondition(mip => mip.MenuItemIdFk.Equals(menuItem))
                .FirstOrDefault();
                
        }

        public MenuItemPrice GetMenuItemPriceWithDetails(int menuItemPriceId)
        {
            return FindByCondition(mip => mip.MenuItemPriceId.Equals(menuItemPriceId))
                .Include(mip => mip.MenuItemIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateMenuItemPrice(MenuItemPrice menuItemPrice)
        {
            Update(menuItemPrice);
        }
    }
}
