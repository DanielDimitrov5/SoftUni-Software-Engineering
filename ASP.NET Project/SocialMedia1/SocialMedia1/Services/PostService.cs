using Microsoft.AspNetCore.Identity;
using SocialMedia1.Data;
using SocialMedia1.Data.Models;
using SocialMedia1.Models;

namespace SocialMedia1.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext context;

        public PostService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void CreatePost(string userId, string content)
        {
            Post post = new Post
            {
                Content = content,
                UserProfileId = userId,
                CreatedOn = DateTime.UtcNow,
            };

            context.Posts.Add(post);

            context.SaveChanges();
        }

        public ICollection<PostViewModel> GetAllPosts(string userId)
        {
            return context.Posts.Where(x => x.UserProfileId == userId).Select(x => new PostViewModel
            {
                Author = x.UserProfile.Name,
                AuthorId = x.UserProfile.Id,
                Content = x.Content,
                CreatedOn = x.CreatedOn
            }).ToList();
        }

        public ICollection<PostViewModel> GetAllPostsByFollowedUsers(string userId)
        {
            if (userId is null)
            {
                return new List<PostViewModel>();
            }

            var currentUser = context.UserProfiles.First(x => x.Id == userId);

            var posts = context.UserProfiles.Where(x => x.FollowedBy.Contains(currentUser))
                .SelectMany(x => x.Posts)
                .ToList()
                .Select(x => new PostViewModel
                {
                    Author = context.UserProfiles.Find(x.UserProfileId).Nickname,
                    AuthorId = x.UserProfile.Id,
                    Content = x.Content,
                    Id = x.Id,
                    CreatedOn = x.CreatedOn,
                })
                .ToList();

            return posts;
        }
    }
}
