using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMedia1.Models;
using SocialMedia1.Services;
using System.Security.Claims;

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
            var model = userProfileService.GetUserProfileData(userManager.GetUserId(HttpContext.User));

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult EditUserProfile(ProfileViewModel model)
        {
            userProfileService
                .EditUserProfileAsync(userManager
                .GetUserId(HttpContext.User), model.Nickname, model.Name, model.Surname, model.IsPrivate, model.City, model.Birthday, model.EmailAddress, model.Bio);

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
            if (id == userManager.GetUserId(HttpContext.User))
            {
                return Redirect("/UserProfiles/MyProfile");
            }

            var model = userProfileService.GetUserProfileData(id);

            if (model is null)
            {
                return Redirect("/");
            }

            return View(model);
        }

        [Authorize]
        public IActionResult Follow(string id)
        {
            userProfileService.FollowUser(id, userManager.GetUserId(HttpContext.User));

            return Redirect($"/UserProfiles/Profile/{id}");
        }

        [Authorize]
        public IActionResult Unfollow(string id)
        {
            userProfileService.UnfollowUser(id, userManager.GetUserId(HttpContext.User));

            return Redirect($"/UserProfiles/Profile/{id}");
        }

        [Authorize]
        public IActionResult ApproveFollowRequest(string requesterId, string currentUserId)
        {
            userProfileService.ApproveFollowRequest(requesterId, currentUserId);

            return Redirect("/Home/FollowRequests");
        }

        [Authorize]
        public IActionResult DeleteFollowRequest(string requesterId)
        {
            userProfileService.DeleteRequest(requesterId);

            return Redirect("/Home/FollowRequests");
        }

        [Authorize]
        public IActionResult Search(string searchTerm)
        {
            var model = userProfileService.GetProfilesBySearchTerm(searchTerm);

            return View(model);
        }

        [Authorize]
        public IActionResult Followers()
        {
            var model = userProfileService.GetAllFollowers(userManager.GetUserId(HttpContext.User));

            return View(model);
        }

        [Authorize]
        public IActionResult RemoveFollower(string id)
        {
            userProfileService.RemoveFollower(userManager.GetUserId(HttpContext.User), id);

            return Redirect("/UserProfiles/Followers");
        }

        [Authorize]
        public IActionResult Following()
        {
            var model = userProfileService.GetAllFollowing(userManager.GetUserId(HttpContext.User));

            return View(model);
        }

        [Authorize]
        public IActionResult UnfollowUser(string id)
        {
            userProfileService.UnfollowUser(id, userManager.GetUserId(HttpContext.User));

            return Redirect("/UserProfiles/Following");
        }
    }
}
