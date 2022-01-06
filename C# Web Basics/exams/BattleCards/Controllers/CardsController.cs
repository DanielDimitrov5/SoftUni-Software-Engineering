using BattleCards.Services;
using BattleCards.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardService service;

        public CardsController(ICardService service)
        {
            this.service = service;
        }

        public HttpResponse All()
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            var cards = new AllCardsViewModel()
            {
                Cards = service.GetAllCards()
            };

            return this.View(cards);
        }

        public HttpResponse Collection()
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            var cards = new AllCardsViewModel()
            {
                Cards = service.GetUsersCards(this.User)
            };

            return this.View(cards);
        }

        public HttpResponse Add()
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddCardInputModel model)
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 5 || model.Name.Length > 15)
            {
                return Error("Name should be between 5 and 15 characters!");
            }

            if (model.Attack < 0)
            {
                return Error("Attack cannot be negative!");
            }

            if (model.Health < 0)
            {
                return Error("Health cannot be negative!");
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 200)
            {
                return Error("Description cannot be more than 200 characters!");
            }

            int cardId = service.AddCard(model.Name, model.Image, model.Keyword, model.Attack, model.Health, model.Description);

            service.AddCard(this.User, cardId);

            return Redirect("/Cards/All");
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/Users/Login");
            }

            string userId = this.User;

            service.AddCardToUsersCollection(User, cardId);

            return Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!IsUserLoggedIn())
            {
                return Redirect("/User/Login");
            }

            service.RemoveFromUsersCollection(User, cardId);

            return Redirect("/Cards/Collection");
        }
    }
}