using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class User
    {
        public User()
        {
            Reservation = new HashSet<Reservation>();
            TableSeating = new HashSet<TableSeating>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName1 { get; set; }
        public string UserSurname { get; set; }
        public string UserContactNumber { get; set; }
        public int? UserRoleIdFk { get; set; }
        public int? EmployeeIdFk { get; set; }

        public virtual Employee EmployeeIdFkNavigation { get; set; }
        public virtual UserRole UserRoleIdFkNavigation { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
        public virtual ICollection<TableSeating> TableSeating { get; set; }
    }
}
