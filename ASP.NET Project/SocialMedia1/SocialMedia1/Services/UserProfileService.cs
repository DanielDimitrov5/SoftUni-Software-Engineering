using SocialMedia1.Data;
using SocialMedia1.Data.Models;
using SocialMedia1.Models;
using System.Linq;

namespace SocialMedia1.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly ApplicationDbContext context;

        public UserProfileService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddUserProfileAsync(string Id)
        {
            string email = context.Users.FirstOrDefault(x => x.Id == Id).Email;

            await context.UserProfiles.AddAsync(new UserProfile { Id = Id, EmailAddress = email });

            await context.SaveChangesAsync();
        }

        public async Task EditUserProfileAsync(string id, string name, string surename, string city, DateTime birthday, string emailaddress, string bio)
        {
            UserProfile userProfile = context.UserProfiles.First(x => x.Id == id);

            userProfile.Name = name;
            userProfile.Surename = surename;
            userProfile.City = city;
            userProfile.Birthday = birthday;
            userProfile.EmailAddress = emailaddress;
            userProfile.Bio = bio;

            await context.SaveChangesAsync();
        }

        public ProfileViewModel GetUserData(string id)
        {
            UserProfile user = context.UserProfiles.First(x => x.Id == id);

            ProfileViewModel model = new ProfileViewModel
            {
                Name = user.Name,
                Surename = user.Surename,
                City = user.City,
                Birthday = user.Birthday,
                EmailAddress = user.EmailAddress,
                Bio = user.Bio,
            };

            return model;
        }
    }
}
