using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class EmployeeRepository: RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return FindAll()
                .OrderBy(em => em.EmployeeIdNumber)
                .ToList();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return FindByCondition(em => em.EmployeeId.Equals(employeeId))
                .FirstOrDefault();
        }

        public Employee GetEmployeeDetails(int employeeId)
        {
            return FindByCondition(em => em.EmployeeId.Equals(employeeId))
                .Include( em => em.RestaurantIdFk)
                .Include(em => em.ProductStockTake)
                .Include(em => em.RestaurantIdFkNavigation)
                .Include(em => em.User)
                .Include(em => em.AttendanceSheet)
                .Include(em => em.EmployeeShift)
                .Include(em => em.ProductWrittenOff)
                .FirstOrDefault();
        }

        public void UpdateEmployee(Employee employee)
        {
            Update(employee);
        }
    }
}
