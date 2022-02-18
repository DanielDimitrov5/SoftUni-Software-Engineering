using SocialMedia1.Data.Models;
using SocialMedia1.Models;

namespace SocialMedia1.Services
{
    public interface IUserProfileService
    {
        Task AddUserProfileAsync(string Id);

        Task EditUserProfileAsync(string id, string nickname, string name, string surename,bool IsPrivate ,string city, DateTime birthday, string emailaddress, string bio);

        ProfileViewModel GetUserProfileData(string id);

        void FollowUser(string id, string currentUserId);

        void UnfollowUser(string id, string currentUserId);

        bool IsUserFollowed(string currentUserId, string userId);

        void ApproveFollowRequest(string requesterId, string currentUser);

        void DeleteRequest(string requesterId);

        bool CheckIfFollowRequestIsSent(string userId, string currentsUserId);

        public ICollection<FollowRequestViewModel> GetAllFollowRequests(string currentUserId);
    }
}
