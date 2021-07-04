using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.Models;
using System;
namespace ExplicitInterfaces.Core
{
    public class Engine
    {
        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                IPerson person = new Citizen(name, age, country);
                IResident resident = new Citizen(name, age, country);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
