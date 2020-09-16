using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class User_CommentRepository: RepositoryBase<UserComment>, IUser_CommentRepository
    {
        public User_CommentRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateUserComment(UserComment userComment)
        {
            Create(userComment);
        }

        public void DeleteUserComment(UserComment userComment)
        {
            Delete(userComment);
        }

        public IEnumerable<UserComment> GetAllComments()
        {
            return FindAll()
                .OrderBy(uc => uc.UserCommentDateCreated)
                .ToList();
        }

        public UserComment GetUserCommentById(int userCommentId)
        {
            return FindByCondition(uc => uc.UserCommentId.Equals(userCommentId))
                .FirstOrDefault();
        }

        public UserComment GetUserCommentWithDetails(int userCommentId)
        {
            return FindByCondition(uc => uc.UserCommentId.Equals(userCommentId))
                .Include(uc => uc.RestaurantIdFkNavigation)
                .Include(uc => uc.StarRating)
                .FirstOrDefault();
        }

        public void UpdateUserComment(UserComment userComment)
        {
            Update(userComment);
        }
    }
}
