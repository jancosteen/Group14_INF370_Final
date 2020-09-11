using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IShift_StatusRepository:IRepositoryBase<ShiftStatus>
    {
        IEnumerable<ShiftStatus> GetAllShiftStatusses();
        ShiftStatus GetShiftStatusById(int shiftStatusId);
        ShiftStatus GetShiftStatusDetails(int shiftStatusId);
        void CreateShiftStatus(ShiftStatus shiftStatus);
        void UpdateShiftStatus(ShiftStatus shiftStatus);
        void DeleteShiftStatus(ShiftStatus shiftStatus);
    }
}
