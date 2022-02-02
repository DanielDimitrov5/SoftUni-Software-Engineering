namespace SocialMedia1.Models
{
    public class MyProfileViewModel : ProfileViewModel
    {
        public MyProfileViewModel()
        {
            Posts = new HashSet<PostViewModel>();
        }

        public ICollection<PostViewModel> Posts { get; set; }
    }
}
