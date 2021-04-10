using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] person = input.Split();

                string name = person[0];
                int age = int.Parse(person[1]);
                string town = person[2];

                Person newPerson = new Person(name, age, town);

                people.Add(newPerson);
            }

            int n = int.Parse(Console.ReadLine());

            Person nPerson = people[n - 1];

            int matches = 0;

            foreach (var person in people)
            {
                if (nPerson.CompareTo(person) == 0)
                {
                    matches++;
                }
            }

            if (matches - 1 > 0)
            {
                Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
