using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class MenuRepository: RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateMenu(Menu menu)
        {
            Create(menu);
        }

        public void DeleteMenu(Menu menu)
        {
            Delete(menu);
        }

        public IEnumerable<Menu> GetAllMenus()
        {
            return FindAll()
                .OrderBy(m => m.MenuRestaurant)
                .ToList();
        }

        public Menu GetMenuById(int menuId)
        {
            return FindByCondition(m => m.MenuId.Equals(menuId))
                .FirstOrDefault();
        }

        public Menu GetMenuWithDetails(int menuId)
        {
            return FindByCondition(m => m.MenuId.Equals(menuId))
                .Include(m => m.MenuRestaurant)
                .FirstOrDefault();
        }

        public void UpdateMenu(Menu menu)
        {
            Update(menu);
        }
    }
}
