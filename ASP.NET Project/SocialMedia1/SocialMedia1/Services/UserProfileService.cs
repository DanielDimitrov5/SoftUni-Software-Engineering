using Microsoft.AspNetCore.Identity;
using SocialMedia1.Data;
using SocialMedia1.Data.Models;
using SocialMedia1.Models;

namespace SocialMedia1.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly ApplicationDbContext context;
        private readonly IPostService postService;

        public UserProfileService(ApplicationDbContext context, IPostService postService)
        {
            this.context = context;
            this.postService = postService;
        }

        public async Task AddUserProfileAsync(string Id)
        {
            string email = context.Users.FirstOrDefault(x => x.Id == Id).Email;

            string nickname = email.Split('@')[0];

            await context.UserProfiles.AddAsync(new UserProfile { Id = Id, Nickname = nickname, EmailAddress = email });

            await context.SaveChangesAsync();
        }

        public async Task EditUserProfileAsync(string id, string nickname,string name, string surename,bool IsPrivate ,string city, DateTime birthday, string emailaddress, string bio)
        {
            UserProfile userProfile = context.UserProfiles.First(x => x.Id == id);

            userProfile.Nickname = nickname;
            userProfile.Name = name;
            userProfile.Surename = surename;
            userProfile.IsPrivate = IsPrivate;
            userProfile.City = city;
            userProfile.Birthday = birthday;
            userProfile.EmailAddress = emailaddress;
            userProfile.Bio = bio;

            await context.SaveChangesAsync();
        }

        public void FollowUser(string id, string currentUserId)
        {
            var userProfile = context.UserProfiles.FirstOrDefault(x => x.Id == id);

            if (userProfile is null)
            {
                return;
            }

            var currentUser = context.UserProfiles.FirstOrDefault(x => x.Id == currentUserId);

            currentUser.Follows.Add(userProfile);
            userProfile.FollowedBy.Add(currentUser);

            context.SaveChanges();
        }

        public ProfileViewModel GetUserData(string id)
        {
            UserProfile user = context.UserProfiles.First(x => x.Id == id);

            ProfileViewModel model = new ProfileViewModel
            {
                Id = id,
                Nickname = user.Nickname,
                Name = user.Name,
                Surename = user.Surename,
                City = user.City,
                Birthday = user.Birthday,
                EmailAddress = user.EmailAddress,
                Bio = user.Bio,
            };

            return model;
        }

        public MyProfileViewModel GetUserProfileData(string id)
        {
            UserProfile user = context.UserProfiles.First(x => x.Id == id);

            var posts = postService.GetAllPosts(id);

            MyProfileViewModel model = new MyProfileViewModel
            {
                Nickname = user.Nickname,
                Name = user.Name,
                Surename = user.Surename,
                City = user.City,
                Age = user.Age,
                Birthday = user.Birthday,
                EmailAddress = user.EmailAddress,
                Bio = user.Bio,
                Posts = posts
            };

            return model;
        }
    }
}
