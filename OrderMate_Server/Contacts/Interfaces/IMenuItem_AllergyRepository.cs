using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IMenuItem_AllergyRepository: IRepositoryBase<MenuItemAllergy>
    {
        IEnumerable<MenuItemAllergy> GetAllMenuItemAllergies();
        MenuItemAllergy GetMenuItemAllergyById(int allergyId, int menuItemId);
        MenuItemAllergy GetMenuItemAllergyWithDetails(int allergyId, int menuItemId);
        void CreateMenuItemAllergy(MenuItemAllergy menuItemAllergy);
        void UpdateMenuItemAllergy(MenuItemAllergy menuItemAllergy);
        void DeleteMenuItemAllergy(MenuItemAllergy menuItemAllergy);
    }
}
