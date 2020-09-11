using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface ISocialMediaRepository: IRepositoryBase<SocialMedia>
    {
        IEnumerable<SocialMedia> GetAllSocialMedias();
        SocialMedia GetSocialMediaById(int socialMediaId);
        SocialMedia GetSocialMediaDetails(int socialMediaId);
        void CreateSocialMedia(SocialMedia socialMedia);
        void UpdateSocialMedia(SocialMedia socialMedia);
        void DeleteSocialMedia(SocialMedia socialMedia);
    }
}
