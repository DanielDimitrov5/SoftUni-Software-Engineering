using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    class Team
    {
        private string name;
        private ICollection<Player> players;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => this.name;

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

        public void RemovePlayer(string name)
        {
            try
            {
                Player player = players.First(x => x.Name == name);

                if (players.Remove(player))
                {

                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Player {name} is not in {Name} team.");
            }
        }

        public void ShowStats()
        {
            int stats = 0;

            if (players.Any())
            {
                stats = (int)Math.Round(players.Average(x => x.Stats));
            }
            Console.WriteLine($"{Name} - {stats}");
        }
    }
}
