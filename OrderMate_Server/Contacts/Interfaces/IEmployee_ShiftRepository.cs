using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IEmployee_ShiftRepository: IRepositoryBase<EmployeeShift>
    {
        IEnumerable<EmployeeShift> GetAllEmployeeShifts();
        EmployeeShift GetEmShiftById(int employeeId, int shiftId);
        EmployeeShift GetEmShiftDetails(int employeeId, int shiftId);
        void CreateEmShift(EmployeeShift employeeShift);
        void UpdateEmShift(EmployeeShift employeeShift);
        void DeleteEmShift(EmployeeShift employeeShift);
    }
}
