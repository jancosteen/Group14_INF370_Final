using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Star_RatingRepository: RepositoryBase<StarRating>, IStar_RatingRepository
    {
        public Star_RatingRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateStarRating(StarRating starRating)
        {
            Create(starRating);
        }

        public void DeleteStarRating(StarRating starRating)
        {
            Delete(starRating);
        }

        public IEnumerable<StarRating> GetAllStarRatings()
        {
            return FindAll()
                .OrderBy(sr => sr.StarRatingId)
                .ToList();
        }

        public StarRating GetStarRatingById(int starRatingId)
        {
            return FindByCondition(sr => sr.StarRatingId.Equals(starRatingId))
                .FirstOrDefault();
        }

        public StarRating GetStarRatingWithDetails(int starRatingId)
        {
            return FindByCondition(sr => sr.StarRatingId.Equals(starRatingId))
                .Include(sr => sr.UserCommentIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateStarRating(StarRating starRating)
        {
            Update(starRating);
        }
    }
}
