using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class UserRoleDetailsDto
    {
        public int UserRoleId { get; set; }
        public string UserRole1 { get; set; }

        public virtual ICollection<UserDto> User { get; set; }
    }
}
