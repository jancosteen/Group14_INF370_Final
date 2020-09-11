using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMate_Server.Resources
{
    public class UserResource
    {
        
        public string Password { get; set; }
        

       
        public string User_Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string User_Surname { get; set; }
        public string User_Contact_Number { get; set; }
        public string UserRoleIdFk { get; set; }
        public int? EmployeeIdFk { get; set; }
    }
}
