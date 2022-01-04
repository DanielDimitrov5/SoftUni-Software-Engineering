using System.Linq;
using BattleCards.Data;
using BattleCards.Models;
using SIS.MvcFramework;

namespace BattleCards.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string CreateUser(string username, string email, string password)
        {
            User user = new User()
            {
                Username = username,
                Email = email,
                Role = IdentityRole.User,
                Password = Hashing(password)
            };

            context.Users.Add(user);

            context.SaveChanges();

            return user.Id;
        }

        public string GetUserId(string username, string password)
        {
            User user = context.Users.FirstOrDefault(x => x.Username == username && x.Password == Hashing(password));

            return user?.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return !context.Users.Any(x => x.Username == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return !context.Users.Any(x => x.Username == username);
        }

        public static string Hashing(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);

            using var hash = System.Security.Cryptography.SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);

            var hashedInputStringBuilder = new System.Text.StringBuilder(128);
            foreach (var b in hashedInputBytes)
            {
                hashedInputStringBuilder.Append(b.ToString("X2"));
            }

            return hashedInputStringBuilder.ToString();
        }
    }
}