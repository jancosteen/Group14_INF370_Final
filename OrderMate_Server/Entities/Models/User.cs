using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public partial class User : IdentityUser
    {
        public User()
        {
            Reservation = new HashSet<Reservation>(); 
        }


        public string User_Name { get; set; } 
        public string User_Surname { get; set; }
        public string User_Contact_Number { get; set; }
       // public string? UserRole { get; set; }
        public int? EmployeeIdFk { get; set; }

        public virtual Employee EmployeeIdFkNavigation { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }

       
        
    }
}
