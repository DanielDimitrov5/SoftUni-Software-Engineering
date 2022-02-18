using System.Collections.Generic;

namespace SocialMedia1.Models
{
    public class IndexViewModel
    {
        public string Id { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string FollowRequestNickname { get; set; }
    }
}
