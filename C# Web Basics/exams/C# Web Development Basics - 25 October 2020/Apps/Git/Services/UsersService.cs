using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Git.Data;
using Git.Data.Models;

namespace Git.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext context;

        public UsersService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string CreateUser(string username, string email, string password)
        {
            User user = new User
            {
                Username = username,
                Email = email,
                Password = ComputeHash(password)
            };

            context.Users.Add(user);

            context.SaveChanges();

            return user.Id;
        }

        public string GetUserId(string username, string password)
        {
            return context.Users.FirstOrDefault(x => x.Username == username && x.Password == ComputeHash(password)).Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return !context.Users.Any(x => x.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return !context.Users.Any(x => x.Username == username);
        }

        private static string ComputeHash(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                return string.Empty;
            }

            using SHA512 shaM = new SHA512Managed();
            return Convert.ToBase64String(shaM.ComputeHash(Encoding.UTF8.GetBytes(inputString)));
        }
    }
}