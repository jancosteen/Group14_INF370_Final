using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IReservationRepository: IRepositoryBase<Reservation>
    {
        IEnumerable<Reservation> GetAllReservations();
        Reservation GetReservationById(int reservationId);
        Reservation GetReservationWithDetails(int reservationId);
        void CreateReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(Reservation reservation);
    }
}
