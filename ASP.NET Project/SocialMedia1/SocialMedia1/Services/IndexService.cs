using SocialMedia1.Data;
using SocialMedia1.Models;

namespace SocialMedia1.Services
{
    public class IndexService/* : IIndexService*/
    {
        private readonly IUserProfileService userProfileService;
        private readonly IPostService postService;

        public IndexService(IUserProfileService userProfileService, IPostService postService, ApplicationDbContext context)
        {
            this.userProfileService = userProfileService;
            this.postService = postService;
        }

        //public ICollection<IndexViewModel> GetIndexViewModel()
        //{
        //    return postService.GetAllPostsByFollowedUsers("31231").Select(x => new IndexViewModel
        //    {
                
        //    }
        //}
    }
}
