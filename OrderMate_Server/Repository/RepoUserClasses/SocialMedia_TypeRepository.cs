using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class SocialMedia_TypeRepository: RepositoryBase<SocialMediaType>, ISocialMedia_TypeRepository
    {
        public SocialMedia_TypeRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateSocialMediaType(SocialMediaType socialMediaType)
        {
            Create(socialMediaType);
        }

        public void DeleteSocialMediaType(SocialMediaType socialMediaType)
        {
            Delete(socialMediaType);
        }

        public IEnumerable<SocialMediaType> GetAllSocialMediaTypes()
        {
            return FindAll()
                .OrderBy(st => st.SocialMediaTypeId)
                .ToList();
        }

        public SocialMediaType GetSocialMediaTypeById(int socialMediaTypeId)
        {
            return FindByCondition(st => st.SocialMediaTypeId.Equals(socialMediaTypeId))
                .FirstOrDefault();
        }

        public SocialMediaType GetSocialMediaTypeWithDetails(int socialMediaTypeId)
        {
            return FindByCondition(st => st.SocialMediaTypeId.Equals(socialMediaTypeId))
                .Include(st => st.SocialMedia)
                .FirstOrDefault();
        }

        public void UpdateSocialMediaType(SocialMediaType socialMediaType)
        {
            Update(socialMediaType);
        }
    }
}
