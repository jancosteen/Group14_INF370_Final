using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Contacts.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository.RepoUserClasses
{
    public class AttendanceSheetRepository: RepositoryBase<AttendanceSheet>, IAttendanceSheetRepository
    {
        public AttendanceSheetRepository(OrderMateDbDel08Context repositoryContext): base(repositoryContext)
        {

        }

        public void CreateAttSheet(AttendanceSheet attendanceSheet)
        {
            Create(attendanceSheet);
        }

        public void DeleteAttSheet(AttendanceSheet attendanceSheet)
        {
            Delete(attendanceSheet);
        }

        public IEnumerable<AttendanceSheet> GetAllAttendanceSeets()
        {
            return FindAll()
                .OrderBy(at => at.EmployeeIdFk)
                .ToList();
        }

        public AttendanceSheet GetAttendanceSheetById(int attSheetId)
        {
            return FindByCondition(at => at.AttendanceSheetId.Equals(attSheetId))
                .FirstOrDefault();
        }

        public AttendanceSheet GetAttendanceSheetDetails(int sttSheetId)
        {
            return FindByCondition(at => at.AttendanceSheetId.Equals(sttSheetId))
                .Include(at => at.EmployeeIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateAttSheet(AttendanceSheet attendanceSheet)
        {
            Update(attendanceSheet);
        }

        
    }
}
