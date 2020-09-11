using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class UserForUpdateDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName1 { get; set; }
        public string UserSurname { get; set; }
        public string UserContactNumber { get; set; }
        public int? UserRoleIdFk { get; set; }
        public int? EmployeeIdFk { get; set; }
    }
}
