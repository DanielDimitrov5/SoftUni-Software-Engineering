namespace FootballManager.Controllers
{
    using MyWebServer.Http;
    using MyWebServer.Controllers;
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return View();
        }
    }
}
