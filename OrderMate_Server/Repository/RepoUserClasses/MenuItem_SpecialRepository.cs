using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class MenuItem_SpecialRepository: RepositoryBase<MenuItemSpecial>, IMenuItem_SpecialRepository
    {
        public MenuItem_SpecialRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateMenuItemSpecial(MenuItemSpecial menuItemSpecial)
        {
            Create(menuItemSpecial);
        }

        public void DeleteMenuItemSpecial(MenuItemSpecial menuItemSpecial)
        {
            Delete(menuItemSpecial);
        }

        public IEnumerable<MenuItemSpecial> GetAllMenuItemSpecials()
        {
            return FindAll()
                .OrderBy(mis => mis.MenuItemIdFk)
                .ToList();
        }

        public MenuItemSpecial GetMenuItemSpecialById(int specialId, int menuItemId)
        {
            return FindByCondition(mis => mis.SpecialIdFk.Equals(specialId) && mis.MenuItemIdFk.Equals(menuItemId))
                .FirstOrDefault();
        }

        public MenuItemSpecial GetMenuItemSpecialWithDetails(int specialId, int menuItemId)
        {
            return FindByCondition(mis => mis.SpecialIdFk.Equals(specialId) && mis.MenuItemIdFk.Equals(menuItemId))
                .Include(mis => mis.MenuItemIdFkNavigation)
                .Include(mis => mis.SpecialIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateMenuItemSpecial(MenuItemSpecial menuItemSpecial)
        {
            Update(menuItemSpecial);
        }
    }
}
