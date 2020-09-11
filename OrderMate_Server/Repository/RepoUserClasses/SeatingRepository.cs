using Contacts.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void DeleteSeating(Seating seating)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seating> GetAllSeatings()
        {
            throw new NotImplementedException();
        }

        public Seating GetSeatingById(int seatingId)
        {
            throw new NotImplementedException();
        }

        public Seating GetSeatingWithDetails(int seatingId)
        {
            throw new NotImplementedException();
        }

        public void UpdateSeating(Seating seating)
        {
            throw new NotImplementedException();
        }
    }
}
