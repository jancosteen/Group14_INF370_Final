using Contacts.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class User_RoleRepository: RepositoryBase<IdentityRole>, IUser_RoleRepository
    {
        public User_RoleRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateUserRole(IdentityRole userRole)
        {
            Create(userRole);
        }

        public void DeleteUserRole(IdentityRole userRole)
        {
            Delete(userRole);
        }

        public IEnumerable<IdentityRole> GetAllUserRoles()
        {
            return FindAll()
                .OrderBy(ur => ur.Name)
                .ToList();
        }

        public IdentityRole GetUserRoleById(string userRoleId)
        {
            return FindByCondition(ur => ur.Id.Equals(userRoleId))
                .FirstOrDefault();
        }

        public IdentityRole GetUserRoleWithDetails(string userRoleId)
        {
            return FindByCondition(ur => ur.Id.Equals(userRoleId))
                .FirstOrDefault();
        }

        public void UpdateUserRole(IdentityRole userRole)
        {
            Update(userRole);
        }
    }
}
