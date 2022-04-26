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

        public DbSet<Group> Groups { get; set; }

        public DbSet<UserProfileGroup> UserProfilesGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<FollowRequest>().HasKey(x => new { x.UserId, x.UserRequesterId });
            builder.Entity<UserProfile>().HasMany(x => x.FollowRequests).WithOne(x => x.User).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserProfileGroup>().HasKey(x => new { x.UserProfileId, x.GroupId });

            builder.Entity<UserProfileGroup>().HasOne(x => x.Group).WithMany(x => x.Users).HasForeignKey(x=>x.GroupId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<UserProfileGroup>().HasOne(x => x.UserProfile).WithMany(x => x.Groups).HasForeignKey(x=>x.UserProfileId).OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<SocialMedia1.Models.CreatePostViewModel> CreatePostViewModel { get; set; }
    }
}