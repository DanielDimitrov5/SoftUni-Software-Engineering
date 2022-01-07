using System;
using System.Collections.Generic;
using SUS.MvcFramework;

namespace Git.Data.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Role = IdentityRole.User;
            Repositories = new HashSet<Repository>();
            Commits = new HashSet<Commit>();
        }

        public new string Id { get; set; }

        public ICollection<Repository> Repositories { get; set; }

        public ICollection<Commit> Commits { get; set; }
    }
}