using SocialMedia1.Data;
using SocialMedia1.Data.Models;
using SocialMedia1.Models;
using Microsoft.AspNetCore.Identity;


namespace SocialMedia1.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly ApplicationDbContext context;
        private readonly IPostService postService;
        private readonly UserManager<IdentityUser> userManager;

        public UserProfileService(ApplicationDbContext context, IPostService postService, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.postService = postService;
            this.userManager = userManager;
        }

        public async Task AddUserProfileAsync(string Id)
        {
            string email = context.Users.FirstOrDefault(x => x.Id == Id).Email;

            string nickname = email.Split('@')[0];

            await context.UserProfiles.AddAsync(new UserProfile { Id = Id, Nickname = nickname, EmailAddress = email });

            await context.SaveChangesAsync();
        }

        public async Task EditUserProfileAsync(string id, string nickname, string name, string surename, bool IsPrivate, string city, DateTime birthday, string emailaddress, string bio)
        {
            UserProfile userProfile = context.UserProfiles.First(x => x.Id == id);

            userProfile.Nickname = nickname;
            userProfile.Name = name;
            userProfile.Surname = surename;
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
            var currentUser = context.UserProfiles.FirstOrDefault(x => x.Id == currentUserId);

            if (CheckIfUsersAreNull(userProfile, currentUser))
            {
                return;
            }

            if (userProfile.IsPrivate)
            {
                SendFollowRequest(id, currentUserId);
                return;
            }

            currentUser.Follows.Add(userProfile);
            userProfile.FollowedBy.Add(currentUser);

            context.SaveChanges();
        }

        public void UnfollowUser(string id, string currentUserId)
        {
            var userProfile = context.UserProfiles.FirstOrDefault(x => x.Id == id);
            var currentUser = context.UserProfiles.FirstOrDefault(x => x.Id == currentUserId);

            if (CheckIfUsersAreNull(userProfile, currentUser))
            {
                return;
            }

            context.Entry(userProfile).Collection(x => x.FollowedBy).Load();
            context.Entry(currentUser).Collection(x => x.Follows).Load();

            currentUser.Follows.Remove(userProfile);
            userProfile.FollowedBy.Remove(currentUser);

            context.SaveChanges();
        }

        public void SendFollowRequest(string id, string currentUserId)
        {
            var userProfile = context.UserProfiles.FirstOrDefault(x => x.Id == id);
            var currentUser = context.UserProfiles.FirstOrDefault(x => x.Id == currentUserId);

            if (CheckIfUsersAreNull(userProfile, currentUser))
            {
                return;
            }

            FollowRequest followRequest = new FollowRequest { UserId = userProfile.Id, UserRequesterId = currentUser.Id };

            userProfile.FollowRequests.Add(followRequest);

            context.SaveChanges();
        }

        public void ApproveFollowRequest(string requesterId, string currentUserId)
        {
            var followRequester = context.UserProfiles.FirstOrDefault(x => x.Id == requesterId);

            var user = context.UserProfiles.FirstOrDefault(x => x.Id == currentUserId);

            if (CheckIfUsersAreNull(followRequester, user))
            {
                return;
            }

            var request = context.FollowRequests.FirstOrDefault(x => x.UserRequesterId == requesterId && x.UserId == currentUserId);

            context.FollowRequests.Remove(request);

            followRequester.Follows.Add(user);
            user.FollowedBy.Add(followRequester);

            context.SaveChanges();
        }

        public void DeleteRequest(string requesterId)
        {
            var followRequester = context.UserProfiles.FirstOrDefault(x => x.Id == requesterId);

            if (CheckIfUsersAreNull(followRequester, followRequester))
            {
                return;
            }

            FollowRequest request = context.FollowRequests.FirstOrDefault(x => x.UserRequesterId == requesterId);

            context.FollowRequests.Remove(request);

            context.SaveChanges();
        }

        public ProfileViewModel GetUserProfileData(string id)
        {
            UserProfile user = context.UserProfiles.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return null;
            }

            context.Entry(user).Collection(x => x.FollowedBy).Load();
            context.Entry(user).Collection(x => x.Follows).Load();

            var posts = postService.GetAllPosts(id);

            ProfileViewModel model = new ProfileViewModel
            {
                Id = user.Id,
                Nickname = user.Nickname,
                Name = user.Name,
                Surname = user.Surname,
                City = user.City,
                Age = user.Age,
                Birthday = user.Birthday,
                EmailAddress = user.EmailAddress,
                Bio = user.Bio,
                Posts = posts,
                FollowersCount = user.FollowedBy.Count(),
                FollowingCount = user.Follows.Count(),
            };

            return model;
        }

        public bool IsUserFollowed(string currentUserId, string userId)
        {
            var currentUser = context.UserProfiles.FirstOrDefault(x => x.Id == currentUserId);

            var userProfile = context.UserProfiles.FirstOrDefault(x => x.Id == userId);

            if (currentUser == null || userProfile == null)
            {
                return false;
            }

            context.Entry(currentUser).Collection(x => x.Follows).Load();

            return currentUser.Follows.Contains(userProfile);
        }

        public ICollection<FollowRequestViewModel> GetAllFollowRequests(string currentUserId)
        {
            return context.FollowRequests.Where(x => x.UserId == currentUserId).Select(x => new FollowRequestViewModel
            {
                RequesterId = x.UserRequester.Id,
                Nickname = x.UserRequester.Nickname,
                CurrentUserId = currentUserId,
            }).ToList();
        }
        public bool CheckIfFollowRequestIsSent(string userId, string currentsUserId)
        {
            return context.FollowRequests.Any(x => x.UserId == userId && x.UserRequesterId == currentsUserId);
        }

        private bool CheckIfUsersAreNull(UserProfile user, UserProfile currentUser)
        {
            return user is null || currentUser is null;
        }

        public ICollection<ProfileViewModel> GetProfilesBySearchTerm(string searchTerm)
        {
            var profiles = context.UserProfiles
                .Where(x => x.Nickname.Contains(searchTerm)
                         || x.Name.Contains(searchTerm)
                         || x.Surname.Contains(searchTerm)
                         || (x.Name + x.Surname).Contains(searchTerm))
                .Select(x => new ProfileViewModel
                {
                    Id = x.Id,
                    Nickname = x.Nickname,
                    Name = x.Name,
                    Surname = x.Surname,
                })
                .ToList();

            return profiles;
        }

        public ICollection<ProfileViewModel> GetAllFollowers(string currentUserId)
        {
            var followers = context.UserProfiles.Where(x => x.Follows.Any(x => x.Id == currentUserId))
                .Select(x => new ProfileViewModel
                {
                    Id = x.Id,
                    Nickname = x.Nickname,
                }).ToList();

            return followers;
        }

        public void RemoveFollower(string currentUserId, string followerId)
        {
            var currentUser = context.UserProfiles.Find(currentUserId);

            context.Entry(currentUser).Collection(x => x.FollowedBy).Load();

            var follower = context.UserProfiles.Find(followerId);

            currentUser.FollowedBy.Remove(follower);

            context.SaveChanges();
        }

        public ICollection<ProfileViewModel> GetAllFollowing(string currentUserId)
        {
            var user = context.UserProfiles.Find(currentUserId);

            context.Entry(user).Collection(x => x.Follows).Load();

            var following = user.Follows
                 .Select(x => new ProfileViewModel
                 {
                     Id = x.Id,
                     Nickname = x.Nickname,
                 }).ToList();

            return following;
        }
    }
}
