using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Services;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly IUserService userService;

        public HomeController(IProductService productService, IUserService userService)
        {
            this.productService = productService;
            this.userService = userService;
        }

        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                var username = userService.GetUsernameById(User.Id);
                
                var model = productService.GetIndexViewModel(username);

                return View(model, "IndexLoggedIn");
            }

            return this.View();
        }
    }
}