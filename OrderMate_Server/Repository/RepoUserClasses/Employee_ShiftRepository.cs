using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Employee_ShiftRepository:RepositoryBase<EmployeeShift>, IEmployee_ShiftRepository
    {
        public Employee_ShiftRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateEmShift(EmployeeShift employeeShift)
        {
            Create(employeeShift);
        }

        public void DeleteEmShift(EmployeeShift employeeShift)
        {
            Delete(employeeShift);
        }

        public IEnumerable<EmployeeShift> GetAllEmployeeShifts()
        {
            return FindAll()
                .OrderBy(es => es.ShiftIdFk)
                .ToList();
        }

        public EmployeeShift GetEmShiftById(int employeeId, int shiftId)
        {
            return FindByCondition(es => es.EmployeeIdFk.Equals(employeeId) && es.ShiftIdFk.Equals(shiftId))
                .FirstOrDefault();
        }

        public EmployeeShift GetEmShiftDetails(int employeeId, int shiftId)
        {
            return FindByCondition(es => es.EmployeeIdFk.Equals(employeeId) && es.ShiftIdFk.Equals(shiftId))
                .Include(es => es.EmployeeIdFkNavigation)
                .Include(es => es.ShiftIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateEmShift(EmployeeShift employeeShift)
        {
            Update(employeeShift);
        }
    }
}
