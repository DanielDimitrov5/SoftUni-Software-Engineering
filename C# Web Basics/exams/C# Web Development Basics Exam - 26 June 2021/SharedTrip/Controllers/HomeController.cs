namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }

            return this.View();
        }
    }
}