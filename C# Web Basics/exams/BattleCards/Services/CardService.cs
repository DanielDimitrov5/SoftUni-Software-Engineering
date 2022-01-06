using System.Collections.Generic;
using System.Linq;
using BattleCards.Data;
using BattleCards.Models;
using BattleCards.ViewModels;

namespace BattleCards.Services
{
    public class CardService : ICardService
    {
        private readonly ApplicationDbContext context;

        public CardService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int AddCard(string name, string img, string keyword, int attack, int health, string description)
        {
            Card card = new Card
            {
                Name = name,
                ImageUrl = img,
                Keyword = keyword,
                Attack = attack,
                Health = health,
                Description = description
            };

            context.Cards.Add(card);
            context.SaveChanges();

            return card.Id;
        }

        public void AddCard(string userId, int cardId)
        {
            UserCard userCard = new UserCard
            {
                UserId = userId,
                CardId = cardId
            };

            context.UserCards.Add(userCard);
            context.SaveChanges();
        }

        public IEnumerable<CardsViewModel> GetAllCards()
        {
            return context.Cards.Select(x => new CardsViewModel
            {
                Name = x.Name,
                Attack = x.Attack,
                Health = x.Health,
                Description = x.Description,
                Image = x.ImageUrl,
                Keyword = x.Keyword,
                Id = x.Id
            }).ToList();
        }

        public IEnumerable<CardsViewModel> GetUsersCards(string userId)
        {
            return context.UserCards
                .Where(x => x.UserId == userId)
                .Select(x => new CardsViewModel
                {
                    Name = x.Card.Name,
                    Attack = x.Card.Attack,
                    Health = x.Card.Health,
                    Description = x.Card.Description,
                    Image = x.Card.ImageUrl,
                    Keyword = x.Card.Keyword,
                    Id = x.Card.Id
                }).ToList();
        }

        public void AddCardToUsersCollection(string userId, int cardId)
        {
            if (context.UserCards.Any(x => x.Card.Id == cardId && x.UserId == userId))
            {
                return;
            }

            context.UserCards.Add(new UserCard
            {
                UserId = userId,
                CardId = cardId
            });

            context.SaveChanges();
        }

        public void RemoveFromUsersCollection(string userId, int cardId)
        {
            if (!context.UserCards.Any(x => x.Card.Id == cardId && x.UserId == userId))
            {
                return;
            }

            context.UserCards.Remove(new UserCard
            {
                UserId = userId,
                CardId = cardId
            });

            context.SaveChanges();
        }
    }
}