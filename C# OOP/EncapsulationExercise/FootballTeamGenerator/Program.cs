using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split(';');

                string command = data[0];
                string teamName = data[1];

                switch (command)
                {
                    case "Team":
                        try
                        {
                            Team newTeam = new Team(teamName);
                            teams.Add(newTeam);
                        }
                        catch (ArgumentException e) 
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case "Add":

                        try
                        {
                            Team currentTeam = teams.First(x => x.Name == teamName);

                            string playerName = data[2];
                            int endurance = int.Parse(data[3]);
                            int sprint = int.Parse(data[4]);
                            int dribble = int.Parse(data[5]);
                            int passing = int.Parse(data[6]);
                            int shooting = int.Parse(data[7]);

                            try
                            {
                                Player newPlayer = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                                currentTeam.AddPlayer(newPlayer);
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }

                        }
                        catch (ArgumentNullException)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        break;
                    case "Remove":

                        Team current = teams.FirstOrDefault(x => x.Name == teamName);

                        current.RemovePlayer(data[2]);
                        break;
                    case "Rating":

                        try
                        {
                            Team team = teams.FirstOrDefault(x => x.Name == teamName);

                            team.ShowStats();
                        }
                        catch (ArgumentNullException)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        break;
                }
            }
        }
    }
}
