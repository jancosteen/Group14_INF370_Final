using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Layout_TypeRepository: RepositoryBase<LayoutType>, ILayout_TypeRepository
    {
        public Layout_TypeRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateLayoutType(LayoutType layoutType)
        {
            Create(layoutType);
        }

        public void DeleteLayoutType(LayoutType layoutType)
        {
            Delete(layoutType);
        }

        public IEnumerable<LayoutType> GetAllLayoutTypess()
        {
            return FindAll()
                .OrderBy(lt => lt.LayoutTypeId)
                .ToList();
        }

        public LayoutType GetLayoutTypeById(int layoutTypeId)
        {
            return FindByCondition(lt => lt.LayoutTypeId.Equals(layoutTypeId))
                .FirstOrDefault();
        }

        public LayoutType GetLayoutTypeWithDetails(int layoutTypeId)
        {
            return FindByCondition(lt => lt.LayoutTypeId.Equals(layoutTypeId))
                .Include(lt => lt.SeatingLayout)
                .FirstOrDefault();
        }

        public void UpdateLayoutType(LayoutType layoutType)
        {
            Update(layoutType);
        }
    }
}
