using System;
using System.Collections.Generic;
using System.Linq;

using BirthdayCelebrations.Contaracts;
using BirthdayCelebrations.Models;

namespace BirthdayCelebrations.Core
{
    public class Engine
    {
        private readonly List<IBirth> birthdays;

        public Engine()
        {
            birthdays = new List<IBirth>();
        }

        public void Run()
        {
            int count = 0;
            int total = 0;
            string n = string.Empty;

            while ((n = Console.ReadLine()) != "result")
            {
                count++;

                total += int.Parse(n);
            }

            Console.WriteLine($"Result: {total * 1.0 / count}");

            return;
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                if (tokens[0] == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];

                    string[] dateTokens = tokens[4].Split('/');

                    int day = int.Parse(dateTokens[0]);
                    int month = int.Parse(dateTokens[1]);
                    int year = int.Parse(dateTokens[2]);

                    DateTime birthday = new DateTime(year, month, day);

                    IBirth citizen = new Citizen(name, age, id, birthday);

                    birthdays.Add(citizen);
                }
                else if (tokens[0] == "Pet")
                {
                    string name = tokens[1];

                    string[] dateTokens = tokens[2].Split('/');

                    int day = int.Parse(dateTokens[0]);
                    int month = int.Parse(dateTokens[1]);
                    int year = int.Parse(dateTokens[2]);

                    DateTime birthday = new DateTime(year, month, day);

                    IBirth pet = new Pet(name, birthday);

                    birthdays.Add(pet);
                }
            }

            int yearFilter = int.Parse(Console.ReadLine());

            foreach (var date in birthdays.Where(x => x.Birthday.Year == yearFilter))
            {
                Console.WriteLine($"{date.Birthday.Day:D2}/{date.Birthday.Month:D2}/{date.Birthday.Year}");
            }
        }
    }
}
