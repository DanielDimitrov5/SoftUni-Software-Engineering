namespace SocialMedia1.Data.Models
{
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserProfileId { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
