using System;

namespace PetFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogs = int.Parse(Console.ReadLine());
            int otherAnimals = int.Parse(Console.ReadLine());

            double dogsFood = dogs * 2.5;
            int otherAnimalsFood = otherAnimals * 4;
            double sum = dogsFood + otherAnimalsFood;

            Console.WriteLine($"{sum} lv.");
        }
    }
}