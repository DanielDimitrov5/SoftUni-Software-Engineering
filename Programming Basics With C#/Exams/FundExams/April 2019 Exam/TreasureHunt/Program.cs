using System;
using System.Collections.Generic;
using System.Linq;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> loot = Console.ReadLine().Split('|').ToList();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Yohoho!")
            {
                string[] token = command.Split(" ", 2);

                switch (token[0])
                {
                    case "Loot":

                        string[] items = token[1].Split();

                        foreach (var item in items)
                        {
                            if (!loot.Contains(item))
                            {
                                loot.Insert(0, item);
                            }
                        }
                        break;
                    case "Drop":

                        int index = int.Parse(token[1]);

                        if (index >= 0 && index < loot.Count)
                        {
                            loot.Add(loot[index]);
                            loot.RemoveAt(index);
                        }

                        break;
                    case "Steal":

                        List<string> stolenItems = new List<string>();

                        int count = int.Parse(token[1]);

                        loot.Reverse();

                        for (int i = 0; i < Math.Min(loot.Count, count); i++)
                        {
                            stolenItems.Add(loot[i]);
                        }

                        stolenItems.Reverse();

                        Console.WriteLine(string.Join(", ", stolenItems));

                        loot.RemoveRange(0, Math.Min(loot.Count, count));
                        loot.Reverse();
                        break;
                }
            }

            if (!loot.Any())
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                double totalLength = 0;

                foreach (var item in loot)
                {
                    totalLength += item.Length;
                }

                Console.WriteLine($"Average treasure gain: {totalLength / loot.Count:F2} pirate credits.");
            }
        }
    }
}
