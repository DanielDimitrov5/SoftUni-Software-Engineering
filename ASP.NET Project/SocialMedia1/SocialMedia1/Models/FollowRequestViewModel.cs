using System.ComponentModel.DataAnnotations;

namespace SocialMedia1.Models
{
    public class FollowRequestViewModel
    {
        [Key]
        public string RequesterId { get; set; }

        public string Nickname { get; set; }

        public string CurrentUserId { get; set; }
    }
}
