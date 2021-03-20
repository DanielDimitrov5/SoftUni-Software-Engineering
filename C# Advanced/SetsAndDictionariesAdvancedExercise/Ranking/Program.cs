namespace Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string contestInput = string.Empty;

            while ((contestInput = Console.ReadLine()) != "end of contests")
            {
                string[] contestData = contestInput.Split(':');

                string contest = contestData[0];
                string password = contestData[1];

                contests[contest] = password;
            }

            Dictionary<string, Dictionary<string, int>> scoreLog = new Dictionary<string, Dictionary<string, int>>();

            string submissionInput = string.Empty;

            while ((submissionInput = Console.ReadLine()) != "end of submissions")
            {
                string[] submission = submissionInput.Split("=>");

                string contest = submission[0];
                string password = submission[1];
                string username = submission[2];
                int score = int.Parse(submission[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password && !scoreLog.ContainsKey(username))
                {
                    scoreLog.Add(username, new Dictionary<string, int>());
                }

                if (contests.ContainsKey(contest) && contests[contest] == password && scoreLog.ContainsKey(username) && !scoreLog[username].ContainsKey(contest))
                {
                    scoreLog[username].Add(contest, 0);
                }

                if (contests.ContainsKey(contest) && contests[contest] == password && scoreLog[username][contest] < score)
                {
                    scoreLog[username][contest] = score;
                }
            }


            scoreLog = scoreLog.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine($"Best candidate is {scoreLog.First().Key} with total {scoreLog.First().Value.Values.Sum()} points.");

            Console.WriteLine("Ranking:");

            foreach (var user in scoreLog.OrderBy(x => x.Key))
            {
                Console.WriteLine(user.Key);

                foreach (var contest in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
