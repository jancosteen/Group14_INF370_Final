using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class SocialMediaRepository: RepositoryBase<SocialMedia>, ISocialMediaRepository
    {
        public SocialMediaRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateSocialMedia(SocialMedia socialMedia)
        {
            Create(socialMedia);
        }

        public void DeleteSocialMedia(SocialMedia socialMedia)
        {
            Delete(socialMedia);
        }

        public IEnumerable<SocialMedia> GetAllSocialMedias()
        {
            return FindAll()
                .OrderBy(sm => sm.SocialMediaId)
                .ToList();
        }

        public SocialMedia GetSocialMediaById(int socialMediaId)
        {
            return FindByCondition(sm => sm.SocialMediaId.Equals(socialMediaId))
                .FirstOrDefault();
        }

        public SocialMedia GetSocialMediaDetails(int socialMediaId)
        {
            return FindByCondition(sm => sm.SocialMediaId.Equals(socialMediaId))
                .Include(sm => sm.RestaurantIdFkNavigation)
                .Include(sm => sm.SocialMediaTypeIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateSocialMedia(SocialMedia socialMedia)
        {
            Update(socialMedia);
        }
    }
}
