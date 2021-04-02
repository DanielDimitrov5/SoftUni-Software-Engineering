using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();

            Func<string, string, bool> criteria = (name, input) =>
            {
                string[] data = input.Split();

                string criteria = data[0];
                string str = data[1];

                switch (criteria)
                {
                    case "StartsWith": return name.StartsWith(str);
                    case "EndsWith": return name.EndsWith(str);
                    case "Length": return name.Length == int.Parse(str);
                    default: return false;
                }
            };

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] tokens = input.Split(" ", 2);

                string command = tokens[0];
                string criterias = tokens[1];

                for (int i = 0; i < guests.Count; i++)
                {
                    switch (command)
                    {
                        case "Double":

                            if (criteria(guests[i], criterias))
                            {
                                guests.Insert(i, guests[i]);
                                i++;
                            }

                            break;
                        case "Remove":

                            if (criteria(guests[i], criterias))
                            {
                                guests.RemoveAt(i);
                                i--;
                            }
                            break;
                    }
                }
            }

            Action<List<string>> print = list =>
            {
                if (list.Any())
                {
                     Console.WriteLine($"{string.Join(", ", list)} are going to the party!");
                }
                else
                {
                    Console.WriteLine("Nobody is going to the party!");
                }
            };

            print(guests);
        }
    }
}
