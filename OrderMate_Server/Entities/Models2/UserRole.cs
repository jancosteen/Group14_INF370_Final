using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class UserRole
    {
        public UserRole()
        {
            User = new HashSet<User>();
        }

        public int UserRoleId { get; set; }
        public string UserRole1 { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
