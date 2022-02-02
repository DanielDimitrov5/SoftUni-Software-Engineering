using SocialMedia1.Models;

namespace SocialMedia1.Services
{
    public interface IPostService
    {
        void CreatePost(string userId, string content);

        ICollection<PostViewModel> GetAllPosts(string userId);

        ICollection<PostViewModel> GetAllPostsByFollowedUsers(string userId);
    }
}
