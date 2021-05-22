using System;
using System.Linq;
using System.Collections.Generic;

namespace FootballTeam
{
    class Team
    {
        private ICollection<Player> players;

        private string name;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string player)
        {
            try
            {
                Player current = players.Where(x => x.Name == player).First();
                players.Remove(current);
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException($"Player {player} is not in {this.Name} team.");
            }
        }

        public void Rating()
        {
            int average = players.Count != 0 ? (int)players.Average(x => x.OverallSkill()) : 0;
            Console.WriteLine($"{name} - {average}");
        }

    }
}
