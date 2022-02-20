using FootballManager.Services;
using FootballManager.ViewModels.Players;
using MyWebServer.Controllers;
using MyWebServer.Http;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayersController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        public HttpResponse All()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var model = playerService.GetAllPlayers();

            return View(model);
        }

        public HttpResponse Add()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Add(AddPlayerInputModel model)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            if (    model.FullName.Length < 5 || model.FullName.Length > 80)
            {
                return Redirect("Add");
            }

            if (string.IsNullOrWhiteSpace(model.ImageUrl))
            {
                return Redirect("Add");
            }

            if (model.Position.Length < 5 || model.Position.Length > 20)
            {
                return Redirect("Add");
            }

            if (model.Speed < 0 || model.Speed > 10)
            {
                return Redirect("Add");
            }

            if (model.Endurance < 0 || model.Endurance > 10)
            {
                return Redirect("Add");
            }

            if (string.IsNullOrEmpty(model.Description) || model.Description.Length > 200)
            {
                return Redirect("Add");
            }

            string currentUser = User.Id;

            playerService.AddPlayer(currentUser, model.FullName, model.ImageUrl, model.Position, model.Speed, model.Endurance, model.Description);

            return Redirect("All");
        }

        public HttpResponse AddToCollection(int playerId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var userId = User.Id;

            if (!playerService.PlayerAlreadyContained(userId, playerId))
            {
                playerService.AddPlayerToUsersCollection(userId, playerId);
            }


            return Redirect("All");
        }

        public HttpResponse Collection()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("Users/Login");
            }

            var userId = User.Id;

            var model = playerService.GetAllPlayersInUsersCollection(userId);

            return View(model);
        }

        public HttpResponse RemoveFromCollection(int playerId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("Users/Login");
            }

            var userId = User.Id;

            playerService.RemovePlayerFromCollection(userId, playerId);

            return Redirect("Collection");
        }
    }
}
