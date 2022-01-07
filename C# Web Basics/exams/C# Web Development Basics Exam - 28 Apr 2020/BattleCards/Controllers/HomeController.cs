namespace BattleCards.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            
            if (IsUserLoggedIn())
            {
                return  Redirect("Cards/All");
            }

            return this.View("index");
        }
    }
}