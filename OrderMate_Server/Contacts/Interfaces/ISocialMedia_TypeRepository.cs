using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface ISocialMedia_TypeRepository: IRepositoryBase<SocialMediaType>
    {
        IEnumerable<SocialMediaType> GetAllSocialMediaTypes();
        SocialMediaType GetSocialMediaTypeById(int socialMediaTypeId);
        SocialMediaType GetSocialMediaTypeWithDetails(int socialMediaTypeId);
        void CreateSocialMediaType(SocialMediaType socialMediaType);
        void UpdateSocialMediaType(SocialMediaType socialMediaType);
        void DeleteSocialMediaType(SocialMediaType socialMediaType);
    }
}
