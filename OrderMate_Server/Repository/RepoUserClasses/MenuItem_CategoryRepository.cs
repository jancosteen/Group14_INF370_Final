using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class MenuItem_CategoryRepository: RepositoryBase<MenuItemCategory>, IMenuItem_CategoryRepository
    {
        public MenuItem_CategoryRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateMenuItemCategory(MenuItemCategory menuItemCat)
        {
            Create(menuItemCat);
        }

        public void DeleteMenuItemCategory(MenuItemCategory menuItemCat)
        {
            Delete(menuItemCat);
        }

        public IEnumerable<MenuItemCategory> GetAllMenuItemCategories()
        {
            return FindAll()
                .OrderBy(mic => mic.MenuItemCategoryId)
                .ToList();
        }

        public MenuItemCategory GetMenuItemcateegoryWithDetails(int menuItemCatId)
        {
            return FindByCondition(mic => mic.MenuItemCategoryId.Equals(menuItemCatId))
                .Include(mic => mic.MenuItem)
                .FirstOrDefault();
        }

        public MenuItemCategory GetMenuITemCategoryById(int menuItemCatId)
        {
            return FindByCondition(mic => mic.MenuItemCategoryId.Equals(menuItemCatId))
                .FirstOrDefault();
        }

        public void UpdateMenuItemCategory(MenuItemCategory menuItemCat)
        {
            Update(menuItemCat);
        }
    }
}
