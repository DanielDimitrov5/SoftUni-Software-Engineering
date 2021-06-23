using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public int Count
        {
            get
            {
                return roster.Count;
            }
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (roster.Any(x => x.Name == name))
            {
                roster.Remove(roster.First(x => x.Name == name));
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            roster.FirstOrDefault(x => x.Name == name).Rank = "Member";
        }

        public void DemotePlayer(string name)
        {
            roster.FirstOrDefault(x => x.Name == name).Rank = "Trial";
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] kickedPlayers = roster.Where(x => x.Class == @class).ToArray();

            roster = roster.Where(x => x.Class != @class).ToList();

            return kickedPlayers;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");

            foreach (Player player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
