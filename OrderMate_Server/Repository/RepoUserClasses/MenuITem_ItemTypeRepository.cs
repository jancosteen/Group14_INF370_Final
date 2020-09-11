using Contacts;
using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class MenuITem_ItemTypeRepository : RepositoryBase<ItemTypeMenuMenuItem>, IMenuItem_ItemTypeRepository
    {
        public MenuITem_ItemTypeRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateMenuItemItemType(ItemTypeMenuMenuItem menuItemItemType)
        {
            Create(menuItemItemType);
        }

        public void DeleteMenuItemItemType(ItemTypeMenuMenuItem menuItemItemType)
        {
            Delete(menuItemItemType);
        }

        public IEnumerable<ItemTypeMenuMenuItem> GetAllMenuItemItemTypes()
        {
            return FindAll()
                .OrderBy(mit => mit.MenuItemTypeIdFk)
                .ToList();
        }

        public ItemTypeMenuMenuItem GetMenuItemItemTypeById(int menuItemTypeId, int menuItemId)
        {
            return FindByCondition(mit => mit.MenuItemTypeIdFk.Equals(menuItemTypeId) && mit.MenuItemIdFk.Equals(menuItemId))
                .FirstOrDefault();
        }

        public ItemTypeMenuMenuItem GetMenuItemItemTypeWithDetails(int menuItemTypeId, int menuItemId)
        {
            return FindByCondition(mit => mit.MenuItemTypeIdFk.Equals(menuItemTypeId) && mit.MenuItemIdFk.Equals(menuItemId))
                .Include(mit => mit.MenuItemIdFkNavigation)
                .Include(mit => mit.MenuItemTypeIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateMenuItemItemType(ItemTypeMenuMenuItem menuItemItemType)
        {
            Update(menuItemItemType);
        }
    }
    
}
