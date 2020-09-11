using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class UserRole : IdentityRole
    {
        public UserRole()
        {
            User = new HashSet<User>();
        }

        public string UserRole1 { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
