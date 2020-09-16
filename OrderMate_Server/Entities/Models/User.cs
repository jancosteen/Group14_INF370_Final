using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class User : IdentityUser
    {
        public User()
        {
            OrderLine = new HashSet<OrderLine>();
            Reservation = new HashSet<Reservation>();
            UserUserImage = new HashSet<UserUserImage>();
            UserUserRole = new HashSet<UserUserRole>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string ContactNumber { get; set; }
        public int? EmployeeIdFk { get; set; }

        public virtual Employee EmployeeIdFkNavigation { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
        public virtual ICollection<UserUserImage> UserUserImage { get; set; }
        public virtual ICollection<UserUserRole> UserUserRole { get; set; }
    }
}
