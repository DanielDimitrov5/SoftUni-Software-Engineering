using System.Linq;
using SharedTrip.Data;
using SharedTrip.Models;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Register(string username, string email, string password)
        {

            User user = new User()
            {
                Username = username,
                Email = email,
                Password = Hashing(password),
            };


            context.Users.Add(user);

            context.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            return context.Users.FirstOrDefault(x => x.Username == username && x.Password == Hashing(password))?.Id;
        }
        public bool UsernameExists(string username)
        {
            return context.Users.Any(x => x.Username == username);
        }

        public bool EmailExists(string email)
        {
            return context.Users.Any(x=>x.Email == email);
        }

        private static string Hashing(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using var hash = System.Security.Cryptography.SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);

            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new System.Text.StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }

        public string GetUsernameById(string Id)
        {
            return context.Users.Find(Id).Username;
        }
    }
}