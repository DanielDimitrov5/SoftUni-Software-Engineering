using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia1.Data.Models;

namespace SocialMedia1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}