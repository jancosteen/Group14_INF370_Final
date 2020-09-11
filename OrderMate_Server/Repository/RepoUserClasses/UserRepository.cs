using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
        public UserRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateUser(User user)
        {
            Create(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return FindAll()
                .OrderBy(u => u.UserName)
                .ToList();
        }

        public User GetUserById(string userId)
        {
            return FindByCondition(u => u.Id.Equals(userId))
                .FirstOrDefault();
        }
        public User GetUserByUsername(string username)
        {
            return FindByCondition(u => u.UserName.Equals(username))
                .FirstOrDefault();
        }

        public User GetUserWithDetails(string userRoleId)//typo, keep as is
        {
            return FindByCondition(u => u.Id.Equals(userRoleId))
                .Include(u => u.EmployeeIdFkNavigation)
                .Include(u => u.Reservation)
                //.Include(u => u.TableSeating)
              //  .Include(u => u.UserRoleIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateUser(User user)
        {
            UpdateUser(user);
        }
    }
}
