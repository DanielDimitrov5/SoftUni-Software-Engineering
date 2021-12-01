using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SoftJail.DataProcessor;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.Dto.Export;

namespace VaporStore.DataProcessor
{
    using System;
    using Data;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = context.Genres
                .Where(x => genreNames.Contains(x.Name))
                .ToArray()
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games.Where(x => x.Purchases.Any()).Select(g => new
                    {
                        Id = g.Id,
                        Title = g.Name,
                        Developer = g.Developer.Name,
                        Tags = string.Join(", ", g.GameTags.Select(t => t.Tag.Name)),
                        Players = g.Purchases.Count
                    })
                        .OrderByDescending(o => o.Players)
                        .ThenBy(o => o.Id),
                    TotalPlayers = x.Games.Sum(p => p.Purchases.Count)
                })
                .OrderByDescending(o => o.TotalPlayers)
                .ThenBy(o => o.Id);

            string json = JsonConvert.SerializeObject(genres, Formatting.Indented);

            return json;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var users = context.Users
                .ToArray()
                .Where(x => x.Cards.Any(p => p.Purchases.Any()))
                .Select(x => new ExportUserDto
                {
                    username = x.Username,
                    Purchases = context.Purchases
                        .ToArray()
                        .Where(c => c.Card.User.Username == x.Username &&
                                    c.Type.ToString() == storeType)
                        .Select(p => new ExportPurchaseDto()
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new ExportGameDto()
                            {
                                title = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price
                            }
                        })
                        .OrderBy(o => DateTime.ParseExact(o.Date, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture))
                        .ToArray(),
                    TotalSpent = context.Purchases
                        .ToArray()
                        .Where(c => c.Card.User.Username == x.Username &&
                                    c.Type.ToString() == storeType).Sum(s => s.Game.Price)
                })
                .Where(x=>x.Purchases.Any())
                .OrderByDescending(o => o.TotalSpent)
                .ThenBy(o => o.username)
                .ToArray();

            string xml = XmlConverter.Serialize(users, "Users");

            return xml;
        }
    }
}