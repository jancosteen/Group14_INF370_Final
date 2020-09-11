using Entities.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IUser_RoleRepository: IRepositoryBase<IdentityRole>
    {
        IEnumerable<IdentityRole> GetAllUserRoles();
        IdentityRole GetUserRoleById(string userRoleId);
        IdentityRole GetUserRoleWithDetails(string userRoleId);
        void CreateUserRole(IdentityRole userRole);
        void UpdateUserRole(IdentityRole userRole);
        void DeleteUserRole(IdentityRole userRole);
    }
}
