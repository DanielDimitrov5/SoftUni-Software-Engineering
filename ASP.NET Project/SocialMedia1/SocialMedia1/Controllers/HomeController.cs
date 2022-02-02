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

        public HomeController(ILogger<HomeController> logger, IPostService postService, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            this.postService = postService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = userManager.GetUserId(HttpContext.User);

            var model = postService.GetAllPostsByFollowedUsers(userId);

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