using System.Text.RegularExpressions;
using BattleCards.Services;
using BattleCards.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;


namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }

        public HttpResponse Login()
        {
            if (IsUserLoggedIn())
            {
                Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (IsUserLoggedIn())
            {
                Redirect("/");
            }

            string userId = service.GetUserId(username, password);

            if (userId == null)
            {
                return Error("Invalid Username or Password!");
            }

            SignIn(userId);

            return Redirect("/Cards/All");
        }

        public HttpResponse Register()
        {
            if (IsUserLoggedIn())
            {
                Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel model)
        {
            if (IsUserLoggedIn())
            {
                Redirect("/");
            }

            if (model.Username is null || model.Username.Length < 5 || model.Username.Length > 20)
            {
                return Error("Username should be between 5 and 20 characters.");
            }

            if (!Regex.IsMatch(model.Username, @"^[A-z0-9\.]+$"))
            {
                return this.Error("Invalid username. Only alphanumeric characters are allowed.");
            }

            if (string.IsNullOrWhiteSpace(model.Email) || !Regex.Match(model.Email, @"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b").Success)
            {
                return this.Error("Invalid Email address!");
            }

            if (model.Password == null || model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Error("Invalid password. The password should be between 6 and 20 characters.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Error("Passwords should be the same.");
            }

            if (!this.service.IsUsernameAvailable(model.Username))
            {
                return this.Error("Username already taken.");
            }

            if (!this.service.IsEmailAvailable(model.Email))
            {
                return this.Error("Email address already taken.");
            }

            service.CreateUser(model.Username, model.Email, model.Password);

            return Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}