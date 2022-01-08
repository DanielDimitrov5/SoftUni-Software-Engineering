using System.Text.RegularExpressions;
using Git.Services;
using Git.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (IsUserSignedIn())
            {
                return Redirect("/Repositories/All");
            }

            return View();
        }
        
        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (IsUserSignedIn())
            {
                return Redirect("/Repositories/All");
            }

            string userId = usersService.GetUserId(username, password);

            if (userId is null)
            {
                return Error("Invalid username or password.");
            }

            SignIn(userId);

            return Redirect("/Repositories/All");
        }

        public HttpResponse Register()
        {
            if (IsUserSignedIn())
            {
                return Redirect("/Repositories/All");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel model)
        {
            if (IsUserSignedIn())
            {
                return Redirect("/Repositories/All");
            }

            if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Length < 5 || model.Username.Length > 20)
            {
                return Error("Username should be between 5 and 20 characters.");
            }

            if (!usersService.IsUsernameAvailable(model.Username))
            {
                return Error("Username already in use.");
            }

            if (!Regex.IsMatch(model.Email, @"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b"))
            {
                return Error("Invalid email address.");
            }

            if (!usersService.IsEmailAvailable(model.Email))
            {
                return Error("Email already in use.");
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                return Error("Password should be between 6 and 20 characters.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return Error("Passwords should be the same.");
            }

            usersService.CreateUser(model.Username, model.Email, model.Password);

            return Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!IsUserSignedIn())
            {
                return Redirect("/");
            }

            SignOut();

            return Redirect("/");
        }
    }
}