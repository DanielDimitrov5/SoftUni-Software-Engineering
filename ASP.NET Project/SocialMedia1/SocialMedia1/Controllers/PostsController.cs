using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMedia1.Models;
using SocialMedia1.Services;

namespace SocialMedia1.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService postService;
        private readonly UserManager<IdentityUser> userManager;

        public PostsController(IPostService postService, UserManager<IdentityUser> userManager)
        {
            this.postService = postService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreatePost(CreatePostViewModel model)
        {
            var userId = userManager.GetUserId(HttpContext.User);

            postService.CreatePost(userId, model.Content);

            return Redirect("/Posts/CreatePost"); //!!!
        }
    }
}
