using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IAttendanceSheetRepository: IRepositoryBase<AttendanceSheet>
    {
        IEnumerable<AttendanceSheet> GetAllAttendanceSeets();
        AttendanceSheet GetAttendanceSheetById(int attSheetId);
        AttendanceSheet GetAttendanceSheetDetails(int sttSheetId);
        void CreateAttSheet(AttendanceSheet attendanceSheet);
        void UpdateAttSheet(AttendanceSheet attendanceSheet);
        void DeleteAttSheet(AttendanceSheet attendanceSheet);
    }
}
