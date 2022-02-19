using CarShop.Services;
using CarShop.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Models;
using System.Text.RegularExpressions;

namespace CarShop.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
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

            if (model.Username.Length < 4 || model.Username.Length > 20)
            {
                return Error("Username should be between 4 and 20 characters!");
            }


            if (userService.UsernameExists(model.Username))
            {
                return Error("Username already taken!");
            }

            if (string.IsNullOrWhiteSpace(model.Email) || !Regex.Match(model.Email, @"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b").Success)
            {
                return Error("Invalid email address!");
            }

            if (userService.EmailExists(model.Email))
            {
                return Error("Email already taken!");
            }

            if (model.Password.Length < 5 || model.Password.Length > 20)
            {
                return Error("Password should be between 5 and 20 characters!");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return Error("Passwords should be the same!");
            }

            userService.Register(model.Username, model.Email, model.Password, model.UserType);

            return Redirect("Login");
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
                return Error("Invalid username or password.");
            }

            SignIn(userId);

            return Redirect("/");
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
