using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage.Core
{
    public class Engine
    {
        private readonly List<IBuyer> buyers;

        public Engine()
        {
            buyers = new List<IBuyer>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens.Length == 4)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birthday = tokens[3];

                    if (buyers.Any(x => x.Name == name) == false)
                    {
                        Citizen citizen = new Citizen(name, age, id, birthday);
                        buyers.Add(citizen);
                    }
                }
                else if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];

                    if (buyers.Any(x => x.Name == name) == false)
                    {
                        Rebel rebel = new Rebel(name, age, group);
                        buyers.Add(rebel);
                    }
                }
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (buyers.Any(x => x.Name == input))
                {
                    buyers.Where(x => x.Name == input).First().BuyFood();
                }
            }

            int totalFood = buyers.Sum(x => x.Food);

            Console.WriteLine(totalFood);
        }
    }
}
