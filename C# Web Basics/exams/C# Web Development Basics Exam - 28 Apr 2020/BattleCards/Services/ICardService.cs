using System.Collections.Generic;
using BattleCards.ViewModels;

namespace BattleCards.Services
{
    public interface ICardService
    {
        int AddCard(string name, string img, string keyword, int attack, int health, string description);

        void AddCard(string userId, int cardId);

        IEnumerable<CardsViewModel> GetAllCards();

        IEnumerable<CardsViewModel> GetUsersCards(string userId);

        void AddCardToUsersCollection(string userId, int cardId);

        void RemoveFromUsersCollection(string userId, int cardId);
    }
}