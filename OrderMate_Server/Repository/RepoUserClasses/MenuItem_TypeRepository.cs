using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class MenuItem_TypeRepository: RepositoryBase<MenuItemType>, IMenuItem_TypeRepository
    {
        public MenuItem_TypeRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateMenuItemType(MenuItemType menuItemType)
        {
            Create(menuItemType);
        }

        public void DeleteMenuItemType(MenuItemType menuItemType)
        {
            Delete(menuItemType);
        }

        public IEnumerable<MenuItemType> GetAllMenuItemTypes()
        {
            return FindAll()
                .OrderBy(mit => mit.MenuItemTypeId)
                .ToList();
        }

        public MenuItemType GetMenuITemTypeById(int menuItemTypeId)
        {
            return FindByCondition(mit => mit.MenuItemTypeId.Equals(menuItemTypeId))
                .FirstOrDefault();
        }

        public MenuItemType GetMenuItemTypeWithDetails(int menuItemTypeId)
        {
            return FindByCondition(mit => mit.MenuItemTypeId.Equals(menuItemTypeId))
                .Include(mit => mit.ItemTypeMenuMenuItem)
                .FirstOrDefault();
        }

        public void UpdateMenuItemtype(MenuItemType menuItemType)
        {
            Update(menuItemType);
        }
    }
}
