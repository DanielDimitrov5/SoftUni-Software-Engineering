using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeam
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string teamName = tokens[1];
                try
                {
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

                            Team current = teams.Where(x => x.Name == teamName).FirstOrDefault();

                            if (current == null)
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }
                            else
                            {
                                string playerName = tokens[2];
                                int endurance = int.Parse(tokens[3]);
                                int sprint = int.Parse(tokens[4]);
                                int dribble = int.Parse(tokens[5]);
                                int passing = int.Parse(tokens[6]);
                                int shooting = int.Parse(tokens[7]);

                                try
                                {
                                    Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                                    current.AddPlayer(player);
                                }
                                catch (ArgumentException e)
                                {
                                    Console.WriteLine(e.Message);
                                }

                            }
                            break;
                        case "Remove":

                            string playerToRemove = tokens[2];

                            Team currentTeam = teams.Where(x => x.Name == teamName).First();

                            try
                            {
                                currentTeam.RemovePlayer(playerToRemove);
                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case "Rating":

                            Team team = teams.FirstOrDefault(x => x.Name == teamName);

                            if (team == null)
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                            }

                            team.Rating();
                            break;
                    }
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
