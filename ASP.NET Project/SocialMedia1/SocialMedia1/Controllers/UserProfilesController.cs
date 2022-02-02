using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMedia1.Data;
using SocialMedia1.Models;
using SocialMedia1.Services;
using System.Text;

namespace SocialMedia1.Controllers
{
    public class UserProfilesController : Controller
    {

        private readonly IUserProfileService userProfileService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext context;

        public UserProfilesController(IUserProfileService userProfileService, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            this.userProfileService = userProfileService;
            this.userManager = userManager;
            this.context = context;
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
            userProfileService.EditUserProfileAsync(userManager.GetUserId(HttpContext.User), model.Nickname, model.Name, model.Surename, model.IsPrivate, model.City, model.Birthday, model.EmailAddress, model.Bio);

            return View();
        }

        [Authorize]
        public IActionResult MyProfile()
        {
            var model = userProfileService.GetUserProfileData(userManager.GetUserId(HttpContext.User));

            return View(model);
        }

        [Authorize]
        public IActionResult Profile(string id)
        {
            var model = userProfileService.GetUserData(id);

            return View(model);
        }

        public IActionResult Follow(string id)
        {
            userProfileService.FollowUser(id, userManager.GetUserId(HttpContext.User));

            return Redirect($"/UserProfiles/Profile/{id}");
        }
    }
}
