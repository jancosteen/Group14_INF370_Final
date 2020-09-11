using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IUser_CommentRepository: IRepositoryBase<UserComment>
    {
        IEnumerable<UserComment> GetAllComments();
        UserComment GetUserCommentById(int userCommentId);
        UserComment GetUserCommentWithDetails(int userCommentId);
        void CreateUserComment(UserComment userComment);
        void UpdateUserComment(UserComment userComment);
        void DeleteUserComment(UserComment userComment);
    }
}
