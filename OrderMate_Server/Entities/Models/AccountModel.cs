using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class AccountModel
    {
        public string Username { get; set; }
       
        public string Email { get; set; }

        public string Password { get; set; }

       
        public string ConfirmPassword { get; set; }

        public string User_Name { get; set; }
        public string User_Surname { get; set; }
        public string User_Contact_Number { get; set; }
        public string[] UserRole { get; set; }
        public Employee? Employee { get; set; }
    }
}
