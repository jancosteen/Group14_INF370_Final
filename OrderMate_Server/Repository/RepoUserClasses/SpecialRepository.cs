using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class SpecialRepository: RepositoryBase<Special>, ISpecialRepository
    {
        public SpecialRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateSpecial(Special special)
        {
            Create(special);
        }

        public void DeleteSpecial(Special special)
        {
            Delete(special);
        }

        public IEnumerable<Special> GetAllSpecials()
        {
            return FindAll()
                .OrderBy(s => s.SpecialName)
                .ToList();
        }

        public Special GetSpecialById(int specialId)
        {
            return FindByCondition(s => s.SpecialId.Equals(specialId))
                .FirstOrDefault();
        }

        public Special GetSpecialWithDetails(int specialId)
        {
            return FindByCondition(s => s.SpecialId.Equals(specialId))
                .Include(s => s.MenuItemSpecial)
                //.Include(s => s.OrderLine)
                .FirstOrDefault();
        }

        public void UpdateSpecial(Special special)
        {
            Update(special);
        }
    }
}
