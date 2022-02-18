using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMedia1.Models;
using SocialMedia1.Services;
using System.Diagnostics;

namespace SocialMedia1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostService postService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IUserProfileService userProfileService;

        public HomeController(ILogger<HomeController> logger, IPostService postService, UserManager<IdentityUser> userManager, IUserProfileService userProfileService)
        {
            _logger = logger;
            this.postService = postService;
            this.userManager = userManager;
            this.userProfileService = userProfileService;
        }

        public IActionResult Index()
        {
            var userId = userManager.GetUserId(HttpContext.User);

            var postModel = postService.GetAllPostsByFollowedUsers(userId);

            return View(postModel);
        }

        public IActionResult FollowRequests()
        {
            var userId = userManager.GetUserId(HttpContext.User);

            var model = userProfileService.GetAllFollowRequests(userId);

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}