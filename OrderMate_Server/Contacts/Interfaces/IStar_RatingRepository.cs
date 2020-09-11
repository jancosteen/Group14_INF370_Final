using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IStar_RatingRepository: IRepositoryBase<StarRating>
    {
        IEnumerable<StarRating> GetAllStarRatings();
        StarRating GetStarRatingById(int starRatingId);
        StarRating GetStarRatingWithDetails(int starRatingId);
        void CreateStarRating(StarRating starRating);
        void UpdateStarRating(StarRating starRating);
        void DeleteStarRating(StarRating starRating);
    }
}
