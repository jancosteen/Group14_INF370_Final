using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects 
{
    public class UserForCreationDto 
    {
       

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        public string User_Name { get; set; }
        public string User_Surname { get; set; }
        public string User_Contact_Number { get; set; }
        public string? UserRoleIdFk { get; set; }
        public int? EmployeeIdFk { get; set; }

        
    }
}
