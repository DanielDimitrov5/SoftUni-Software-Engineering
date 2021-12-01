using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using SoftJail.DataProcessor;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dto.Import;

namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public static class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var gamesDtos = JsonConvert.DeserializeObject<IEnumerable<GameDto>>(jsonString);

            foreach (var gamesDto in gamesDtos)
            {
                if (!IsValid(gamesDto) || !gamesDto.Tags.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Game game = new Game()
                {
                    Name = gamesDto.Name,
                    Price = gamesDto.Price,
                    ReleaseDate = gamesDto.ReleaseDate
                };

                if (!context.Developers.Any(x => x.Name == gamesDto.Developer))
                {
                    Developer developer = new Developer()
                    {
                        Name = gamesDto.Developer
                    };

                    context.Developers.Add(developer);
                    context.SaveChanges();
                }

                game.Developer = context.Developers.First(x => x.Name == gamesDto.Developer);

                if (!context.Genres.Any(x => x.Name == gamesDto.Genre))
                {
                    Genre genre = new Genre()
                    {
                        Name = gamesDto.Genre
                    };

                    context.Genres.Add(genre);
                    context.SaveChanges();
                }

                game.Genre = context.Genres.First(x => x.Name == gamesDto.Genre);

                context.Games.Add(game);
                context.SaveChanges();

                foreach (var gamesDtoTag in gamesDto.Tags)
                {
                    if (!context.Tags.Any(x => x.Name == gamesDtoTag))
                    {
                        Tag tag = new Tag()
                        {
                            Name = gamesDtoTag
                        };

                        context.Tags.Add(tag);
                        context.SaveChanges();
                    }

                    context.GameTags.Add(new GameTag()
                    { Game = game, Tag = context.Tags.First(x => x.Name == gamesDtoTag) });
                    context.SaveChanges();
                }

                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count()} tags");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var usersDtos = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(jsonString);

            foreach (var userDto in usersDtos)
            {
                if (!IsValid(userDto) || !userDto.Cards.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User user = new User()
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                context.Users.Add(user);
                context.SaveChanges();

                user.Cards = userDto.Cards.Select(x => new Card()
                {
                    Number = x.Number,
                    Cvc = x.CVC,
                    Type = Enum.Parse<CardType>(x.Type),
                }).ToArray();

                context.SaveChanges();

                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var purchaseDtos = XmlConverter.Deserializer<PurchaseDto>(xmlString, "Purchases");

            List<Purchase> purchases = new List<Purchase>();

            foreach (var purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Purchase purchase = new Purchase()
                {
                    Game = context.Games.First(x => x.Name == purchaseDto.title),
                    Type = Enum.Parse<PurchaseType>(purchaseDto.Type),
                    ProductKey = purchaseDto.Key,
                    Card = context.Cards.First(x => x.Number == purchaseDto.Card),
                    Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                };

                purchases.Add(purchase);

                sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}