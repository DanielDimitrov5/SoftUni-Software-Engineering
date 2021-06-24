using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> food = new Dictionary<int, string>
            {
                {  25, "Bread" },
                {  50, "Cake" },
                {  75, "Pastry" },
                {  100, "Fruit Pie" }
            };

            Dictionary<string, int> cookedFood = new Dictionary<string, int>
            {
                {"Bread", 0 },
                {"Cake", 0 },
                {"Pastry", 0 },
                {"Fruit Pie", 0 },
            };

            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            while (liquids.Any() && ingredients.Any())
            {
                int sum = liquids.Peek() + ingredients.Peek();

                if (food.ContainsKey(sum))
                {
                    liquids.Dequeue();
                    ingredients.Pop();

                    cookedFood[food.First(x => x.Key == sum).Value]++;
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Push(ingredients.Pop() + 3);
                }
            }

            Console.WriteLine(cookedFood.All(x => x.Value > 0) ? "Wohoo! You succeeded in cooking all the food!" :
                                                                 "Ugh, what a pity! You didn't have enough materials to cook everything.");

            Console.WriteLine($"Liquids left: {(liquids.Any() ? string.Join(", ", liquids) : "none")}");

            Console.WriteLine($"Ingredients left: {(ingredients.Any() ? string.Join(", ", ingredients) : "none")}");

            foreach (var item in cookedFood.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
