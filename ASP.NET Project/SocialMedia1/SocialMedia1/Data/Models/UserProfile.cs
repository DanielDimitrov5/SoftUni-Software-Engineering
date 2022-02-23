using System.ComponentModel.DataAnnotations;

namespace SocialMedia1.Data.Models
{
    public class UserProfile
    {
        public UserProfile()
        {
            Posts = new HashSet<Post>();
            Follows = new HashSet<UserProfile>();
            FollowedBy  = new HashSet<UserProfile>();
            FollowRequests = new HashSet<FollowRequest>();
        }

        [Key]
        public string Id { get; set; }

        public string Nickname { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? City { get; set; }

        public DateTime Birthday { get; set; }

        public int Age => (DateTime.Now - Birthday).Days / 365;

        public string? EmailAddress { get; set; }

        public string? Bio { get; set; }

        public bool IsPrivate { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<UserProfile> Follows { get; set; }

        public virtual ICollection<UserProfile> FollowedBy { get; set; }

        public virtual ICollection<FollowRequest> FollowRequests { get; set; }
}
}
