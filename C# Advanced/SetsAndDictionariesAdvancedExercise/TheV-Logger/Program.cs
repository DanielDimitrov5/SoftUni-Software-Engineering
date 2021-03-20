using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> log = new Dictionary<string, List<string>>();
            Dictionary<string, int> followingLog = new Dictionary<string, int>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] inputArray = input.Split();

                string vlogger = inputArray[0];
                string command = inputArray[1];

                switch (command)
                {
                    case "joined":
                        if (!log.ContainsKey(vlogger))
                        {
                            log.Add(vlogger, new List<string>());
                            followingLog.Add(vlogger, 0);
                        }
                        break;
                    case "followed":
                        string vloggerToBeFollowed = inputArray[2];

                        if (log.ContainsKey(vlogger) && log.ContainsKey(vloggerToBeFollowed) &&
                            vlogger != vloggerToBeFollowed && !log[vloggerToBeFollowed].Contains(vlogger))
                        {
                            log[vloggerToBeFollowed].Add(vlogger);
                            followingLog[vlogger]++;
                        }
                        break;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {log.Count} vloggers in its logs.");

            log = log.OrderByDescending(x => x.Value.Count).ThenBy(x => followingLog[x.Key]).ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine($"1. {log.First().Key} : {log.First().Value.Count} followers, {followingLog[log.First().Key]} following");

            foreach (var follower in log.First().Value.OrderBy(x => x))
            {
                Console.WriteLine($"*  {follower}");
            }

            log.Remove(log.First().Key);

            int count = 1;

            foreach (var follower in log)
            {
                Console.WriteLine($"{++count}. {follower.Key} : {follower.Value.Count} followers, {followingLog[follower.Key]} following");
            }
        }
    }
}
