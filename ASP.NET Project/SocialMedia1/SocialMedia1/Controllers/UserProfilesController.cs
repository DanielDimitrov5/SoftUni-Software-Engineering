using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMedia1.Models;
using SocialMedia1.Services;

namespace SocialMedia1.Controllers
{
    public class UserProfilesController : Controller
    {
        private readonly IUserProfileService userProfileService;
        private readonly UserManager<IdentityUser> userManager;

        public UserProfilesController(IUserProfileService userProfileService, UserManager<IdentityUser> userManager)
        {
            this.userProfileService = userProfileService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult EditUserProfile()
        {
            var model = userProfileService.GetUserData(userManager.GetUserId(HttpContext.User));

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult EditUserProfile(ProfileViewModel model)
        {
            userProfileService.EditUserProfileAsync(userManager.GetUserId(HttpContext.User), model.Name, model.Surename, model.City, model.Birthday, model.EmailAddress, model.Bio);

            return View();
        }

        [Authorize]
        public IActionResult MyProfile()
        {
            var model = userProfileService.GetUserData(userManager.GetUserId(HttpContext.User));

            return View(model);
        }
    }
}
