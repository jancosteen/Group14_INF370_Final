using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class ShiftRepository: RepositoryBase<Shift>, IShiftRepository
    {
        public ShiftRepository(OrderMateDbFinalContext repositoryContext): base(repositoryContext)
        {

        }

        public void CreateShift(Shift shift)
        {
            Create(shift);
        }

        public void DeleteShift(Shift shift)
        {
            Delete(shift);
        }

        public IEnumerable<Shift> GetAllShifts()
        {
            return FindAll()
                .OrderBy(s => s.ShiftStartDateTime)
                .ToList();
        }

        public Shift GetShiftById(int shiftId)
        {
            return FindByCondition(s => s.ShiftId.Equals(shiftId))
                .FirstOrDefault();
        }

        public Shift GetShiftDetails(int shiftId)
        {
            return FindByCondition(s => s.ShiftId.Equals(shiftId))
                .Include(s => s.ShiftStatusIdFkNavigation)
                .Include(s => s.EmployeeShift)
                .FirstOrDefault();
        }

        public void UpdateShift(Shift shift)
        {
            Update(shift);
        }
    }
}
