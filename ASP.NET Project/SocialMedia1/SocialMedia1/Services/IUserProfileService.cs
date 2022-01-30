using SocialMedia1.Models;

namespace SocialMedia1.Services
{
    public interface IUserProfileService
    {
        Task AddUserProfileAsync(string Id);

        Task EditUserProfileAsync(string id, string name, string surename, string city, DateTime birthday, string emailaddress, string bio);

        ProfileViewModel GetUserData(string id);
    }
}
