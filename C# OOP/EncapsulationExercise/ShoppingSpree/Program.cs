using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                string[] person = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < person.Length; i++)
                {
                    string[] tokens = person[i].Split('=', StringSplitOptions.RemoveEmptyEntries);

                    string name = tokens[0];
                    decimal money = decimal.Parse(tokens[1]);

                    Person newPerson = new Person(name, money);

                    people.Add(newPerson);
                }

                string[] product = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < product.Length; i++)
                {
                    string[] tokens = product[i].Split('=', StringSplitOptions.RemoveEmptyEntries);

                    string name = tokens[0];
                    decimal cost = decimal.Parse(tokens[1]);

                    Product newProduct = new Product(name, cost);

                    products.Add(newProduct);
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = command[0];
                string productName = command[1];

                Person currentPerson = people.FirstOrDefault(x => x.Name == personName);
                Product currentProduct = products.FirstOrDefault(x => x.Name == productName);

                if (currentPerson.CanAfford(currentProduct))
                {
                    currentPerson.BuyProduct(currentProduct);
                }
                else
                {
                    Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                }
            }

            foreach (var person in people)
            {
                if (!person.Bag.Any())
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                    continue;
                }

                Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
            }
        }
    }
}
