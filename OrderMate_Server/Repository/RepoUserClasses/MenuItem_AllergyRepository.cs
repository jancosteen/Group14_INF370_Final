using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class MenuItem_AllergyRepository: RepositoryBase<MenuItemAllergy>, IMenuItem_AllergyRepository
    {
        public MenuItem_AllergyRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateMenuItemAllergy(MenuItemAllergy menuItemAllergy)
        {
            Create(menuItemAllergy);
        }

        public void DeleteMenuItemAllergy(MenuItemAllergy menuItemAllergy)
        {
            Delete(menuItemAllergy);
        }

        public IEnumerable<MenuItemAllergy> GetAllMenuItemAllergies()
        {
            return FindAll()
                .OrderBy(mia => mia.AllergyIdFk)
                .ToList();
        }

        public MenuItemAllergy GetMenuItemAllergyById(int allergyId, int menuItemId)
        {
            return FindByCondition(mia => mia.AllergyIdFk.Equals(allergyId) && mia.MenuItemIdFk.Equals(menuItemId))
                .FirstOrDefault();
        }

        public MenuItemAllergy GetMenuItemAllergyWithDetails(int allergyId, int menuItemId)
        {
            return FindByCondition(mia => mia.AllergyIdFk.Equals(allergyId) && mia.MenuItemIdFk.Equals(menuItemId))
                .Include(mia => mia.AllergyIdFkNavigation)
                .Include(mia => mia.MenuItemIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateMenuItemAllergy(MenuItemAllergy menuItemAllergy)
        {
            Update(menuItemAllergy);
        }
    }
}
