using FootballManager.Services;
using FootballManager.ViewModels.Users;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Text.RegularExpressions;

namespace FootballManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public HttpResponse Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel model)
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            string userId = userService.GetUserId(model.Username, model.Password);

            if (userId is null)
            {
                return Redirect("Login");
            }

            SignIn(userId);

            return Redirect("/");
        }

        public HttpResponse Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel model)
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                return Redirect("Register");
            }

            if (userService.UsernameExists(model.Username))
            {
                return Redirect("Register");
            }

            if (model.Email.Length < 10 || model.Email.Length > 60 
                || !Regex.Match(model.Email, @"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b").Success)
            {
                return Redirect("Register");
            }

            if (userService.EmailExists(model.Email))
            {
                return Redirect("Register");
            }

            if (model.Password.Length < 5 || model.Password.Length > 20)
            {
                return Redirect("Register");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return Redirect("Register");
            }

            userService.Register(model.Username, model.Email, model.Password);

            return Redirect("Login");
        }

        public HttpResponse Logout()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("Login");
            }

            SignOut();

            return Redirect("/");
        }
    }
}
