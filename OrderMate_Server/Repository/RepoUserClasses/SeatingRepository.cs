using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class SeatingRepository: RepositoryBase<Seating>, ISeatingRepository
    {
        public SeatingRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateSeating(Seating seating)
        {
            Create(seating);
        }

        public void DeleteSeating(Seating seating)
        {
            Delete(seating);
        }

        public IEnumerable<Seating> GetAllSeatings()
        {
            return FindAll()
                .OrderBy(m => m.SeatingId)
                .ToList();

        }

        public Seating GetSeatingById(int seatingId)
        {
            return FindByCondition(s => s.SeatingId.Equals(seatingId))
                .FirstOrDefault();
        }

        public Seating GetSeatingWithDetails(int seatingId)
        {
            return FindByCondition(s => s.SeatingId.Equals(seatingId))
                .Include(s => s.ReservationIdFkNavigation)
                .Include(s => s.QrCodeSeating)
                .FirstOrDefault();
        }

        public void UpdateSeating(Seating seating)
        {
            Update(seating);
        }
    }
}
