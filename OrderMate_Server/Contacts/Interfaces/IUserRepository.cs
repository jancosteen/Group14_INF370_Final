﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IUserRepository: IRepositoryBase<User>
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(string userId);
        User GetUserWithDetails(string userRoleId);

        User GetUserByUsername(string Username);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
