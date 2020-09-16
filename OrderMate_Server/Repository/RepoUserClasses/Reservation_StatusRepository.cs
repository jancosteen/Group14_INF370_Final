using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Reservation_StatusRepository: RepositoryBase<ReservationStatus>, IReservation_StatusRepository
    {
        public Reservation_StatusRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateReservationStatus(ReservationStatus reservationStatus)
        {
            Create(reservationStatus);
        }

        public void DeleteReservationStatus(ReservationStatus reservationStatus)
        {
            Delete(reservationStatus);
        }

        public IEnumerable<ReservationStatus> GetAllReservationStatusses()
        {
            return FindAll()
                .OrderBy(rs => rs.ReservationStatusId)
                .ToList();
        }

        public ReservationStatus GetReservationStatusById(int resStatusId)
        {
            return FindByCondition(rs => rs.ReservationStatusId.Equals(resStatusId))
                .FirstOrDefault();
        }

        public ReservationStatus GetReservationStatusWithDetails(int resStatusId)
        {
            return FindByCondition(rs => rs.ReservationStatusId.Equals(resStatusId))
                .Include(rs => rs.Reservation)
                .FirstOrDefault();
        }

        public void UpdateReservationStatus(ReservationStatus reservationStatus)
        {
            Update(reservationStatus);
        }
    }
}
