using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IMenuRepository: IRepositoryBase<Menu>
    {
        IEnumerable<Menu> GetAllMenus();
        Menu GetMenuById(int menuId);
        Menu GetMenuWithDetails(int menuId);
        void CreateMenu(Menu menu);
        void UpdateMenu(Menu menu);
        void DeleteMenu(Menu menu);
    }
}
