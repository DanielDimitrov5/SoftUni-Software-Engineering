using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.ViewModels.Players;
using System.Collections.Generic;
using System.Linq;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly FootballManagerDbContext context;

        public PlayerService(FootballManagerDbContext context)
        {
            this.context = context;
        }

        public void AddPlayer(string currentUser, string fullName, string imageUrl, string position, byte speed, byte endurance, string description)
        {
            Player player = new Player
            {
                FullName = fullName,
                ImageUrl = imageUrl,
                Position = position,
                Speed = speed,
                Endurance = endurance,
                Description = description,
            };

            player.UserPlayers.Add(new UserPlayer { UserId = currentUser });

            context.Players.Add(player);

            context.SaveChanges();
        }

        public void AddPlayerToUsersCollection(string userId, int playerId)
        {
            UserPlayer userPlayer = new UserPlayer { UserId = userId, PlayerId = playerId };

            context.UserPlayers.Add(userPlayer);

            context.SaveChanges();
        }

        public ICollection<PlayerViewModel> GetAllPlayers()
        {
            var players = context.Players.Select(x => new PlayerViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                ImageUrl = x.ImageUrl,
                Position = x.Position,
                Speed = x.Speed,
                Endurance = x.Endurance,
                Description = x.Description,
            })
                .ToArray();

            return players;
        }

        public ICollection<PlayerViewModel> GetAllPlayersInUsersCollection(string userId)
        {
            var players = context.UserPlayers.Where(x => x.UserId == userId).Select(x => new PlayerViewModel
            {
                Id = x.Player.Id,
                FullName = x.Player.FullName,
                ImageUrl = x.Player.ImageUrl,
                Position = x.Player.Position,
                Speed = x.Player.Speed,
                Endurance = x.Player.Endurance,
                Description = x.Player.Description,
            })
                .ToArray();

            return players;
        }

        public bool PlayerAlreadyContained(string userId, int playerId)
        {
            return context.UserPlayers.Any(x => x.UserId == userId && x.PlayerId == playerId);
        }

        public void RemovePlayerFromCollection(string userId, int playerId)
        {
            UserPlayer userPlayer = context.UserPlayers.FirstOrDefault(x => x.UserId == userId && x.PlayerId == playerId);

            if (userPlayer is null)
            {
                return;
            }

            context.UserPlayers.Remove(userPlayer);

            context.SaveChanges();
        }
    }
}
