using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> items = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");

                string color = input[0];
                string[] clothes = input[1].Split(',');

                if (!items.ContainsKey(color))
                {
                    items.Add(color, new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!items[color].ContainsKey(clothes[j]))
                    {
                        items[color].Add(clothes[j], 0);
                    }

                    items[color][clothes[j]]++;
                }
            }

            string[] clothToLookFor = Console.ReadLine().Split();

            string clothColor = clothToLookFor[0];
            string clothName = clothToLookFor[1];

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key} clothes:");

                foreach (var cloth in item.Value)
                {
                    if (item.Key == clothColor && cloth.Key == clothName)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.Write($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
