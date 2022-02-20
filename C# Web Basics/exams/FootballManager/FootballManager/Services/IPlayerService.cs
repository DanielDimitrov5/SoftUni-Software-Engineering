using FootballManager.ViewModels.Players;
using System.Collections.Generic;

namespace FootballManager.Services
{
    public interface IPlayerService
    {
        void AddPlayer(string currentUser ,string fullName, string imageUrl, string position, byte speed, byte endurance, string description);

        ICollection<PlayerViewModel> GetAllPlayers();

        void AddPlayerToUsersCollection(string userId, int playerId);

        bool PlayerAlreadyContained(string userId, int playerId);

        ICollection<PlayerViewModel> GetAllPlayersInUsersCollection(string userId);

        void RemovePlayerFromCollection(string userId, int playerId);
    }
}
