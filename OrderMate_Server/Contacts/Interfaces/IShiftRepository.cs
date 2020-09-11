using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IShiftRepository:IRepositoryBase<Shift>
    {
        IEnumerable<Shift> GetAllShifts();
        Shift GetShiftById(int shiftId);
        Shift GetShiftDetails(int shiftId);
        void CreateShift(Shift shift);
        void UpdateShift(Shift shift);
        void DeleteShift(Shift shift);
    }
}
