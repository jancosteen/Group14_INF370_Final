using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class ReservationRepository: RepositoryBase<Reservation>, IReservationRepository
    {
        public ReservationRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateReservation(Reservation reservation)
        {
            Create(reservation);
        }

        public void DeleteReservation(Reservation reservation)
        {
            Delete(reservation);
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            return FindAll()
                .OrderBy(r => r.ReservationDateReserved)
                .ToList();
        }

        public Reservation GetReservationById(int reservationId)
        {
            return FindByCondition(r => r.ReservationId.Equals(reservationId))
                .FirstOrDefault();
        }

        public Reservation GetReservationWithDetails(int reservationId)
        {
            return FindByCondition(r => r.ReservationId.Equals(reservationId))
                .Include(r => r.ReservationStatusIdFkNavigation)
                .Include(r => r.UserIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateReservation(Reservation reservation)
        {
            Update(reservation);
        }
    }
}
