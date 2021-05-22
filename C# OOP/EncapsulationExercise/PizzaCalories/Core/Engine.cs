using System;

namespace PizzaCalories.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] pizzaName = Console.ReadLine().Split();
            string[] doughTokens = Console.ReadLine().Split();

            string name = pizzaName[1];

            string doughType = doughTokens[1];
            string bakingTechnique = doughTokens[2];
            double weight = double.Parse(doughTokens[3]);

            try
            {
                Pizza pizza = new Pizza(name, new Dough(doughType, bakingTechnique, weight));

                string input = string.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingTokens = input.Split();

                    string type = toppingTokens[1];
                    double toppingWeight = double.Parse(toppingTokens[2]);

                    Topping topping = new Topping(type, toppingWeight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
