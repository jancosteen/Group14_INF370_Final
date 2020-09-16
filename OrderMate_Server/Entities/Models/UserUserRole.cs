using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class UserUserRole
    {
        public string UserIdFk { get; set; }
        public int UserRoleIdFk { get; set; }
        public int UserUserRoleId { get; set; }

        public virtual User UserIdFkNavigation { get; set; }
      //  public virtual UserRole UserRoleIdFkNavigation { get; set; }
    }
}
