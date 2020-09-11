using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface ISeatingRepository: IRepositoryBase<Seating>
    {
        IEnumerable<Seating> GetAllSeatings();
        Seating GetSeatingById(int seatingId);
        Seating GetSeatingWithDetails(int seatingId);
        void CreateSeating(Seating seating);
        void UpdateSeating(Seating seating);
        void DeleteSeating(Seating seating);
    }
}
