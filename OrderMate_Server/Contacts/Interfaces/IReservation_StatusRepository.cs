using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IReservation_StatusRepository: IRepositoryBase<ReservationStatus>
    {
        IEnumerable<ReservationStatus> GetAllReservationStatusses();
        ReservationStatus GetReservationStatusById(int resStatusId);
        ReservationStatus GetReservationStatusWithDetails(int resStatusId);
        void CreateReservationStatus(ReservationStatus reservationStatus);
        void UpdateReservationStatus(ReservationStatus reservationStatus);
        void DeleteReservationStatus(ReservationStatus reservationStatus);
    }
}
