using System.ComponentModel.DataAnnotations;

namespace SocialMedia1.Models
{
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
            Posts = new HashSet<PostViewModel>();
        }

        public string Id { get; set; }

        public string Nickname { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        [Display(Name = "Private Profile")]
        public bool IsPrivate { get; set; }

        public string? City { get; set; }

        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        [Display(Name = "Email Address")]
        public string? EmailAddress { get; set; }

        public string? Bio { get; set; }

        public ICollection<PostViewModel> Posts { get; set; }
    }
}
