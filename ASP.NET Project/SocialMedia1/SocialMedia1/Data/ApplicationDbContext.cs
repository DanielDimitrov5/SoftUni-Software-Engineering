using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia1.Data.Models;
using SocialMedia1.Models;

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

        public DbSet<FollowRequest> FollowRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FollowRequest>().HasKey(x => new { x.UserId, x.UserRequesterId });
            builder.Entity<UserProfile>().HasMany(x => x.FollowRequests).WithOne(x => x.User).OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<SocialMedia1.Models.FollowRequestViewModel> FollowRequestViewModel { get; set; }
    }
}