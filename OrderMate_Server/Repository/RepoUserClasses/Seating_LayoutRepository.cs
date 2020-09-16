using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Seating_LayoutRepository: RepositoryBase<SeatingLayout>, ISeating_LayoutRepository
    {
        public Seating_LayoutRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateSeatingLayout(SeatingLayout seatingLayout)
        {
            Create(seatingLayout);
        }

        public void DeleteSeatingLayout(SeatingLayout seatingLayout)
        {
            Delete(seatingLayout);
        }

        public IEnumerable<SeatingLayout> GetAllSeatingLayouts()
        {
            return FindAll()
                .OrderBy(sl => sl.SeatingLayoutId)
                .ToList();
        }

        public SeatingLayout GetSeatingLayoutById(int seatingLayoutId)
        {
            return FindByCondition(sl => sl.SeatingLayoutId.Equals(seatingLayoutId))
                .FirstOrDefault();
        }

        public SeatingLayout GetSeatingLayoutDetails(int seatingLayoutId)
        {
            return FindByCondition(sl => sl.SeatingLayoutId.Equals(seatingLayoutId))
                .Include(sl => sl.LayoutTypeIdFkNavigation)
                .Include(sl => sl.RestaurantIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateSeatingLayout(SeatingLayout seatingLayout)
        {
            Update(seatingLayout);
        }
    }
}
