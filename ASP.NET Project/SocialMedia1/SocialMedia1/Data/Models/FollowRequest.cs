namespace SocialMedia1.Data.Models
{
    public class FollowRequest
    {
        public string UserId { get; set; }

        public UserProfile User { get; set; }

        public string UserRequesterId { get; set; }

        public UserProfile UserRequester { get; set; }
    }
}
