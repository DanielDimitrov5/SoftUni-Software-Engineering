using System;

using WildFarm.Contracts;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double weightGain = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        { }

        public override void Eat(Food food)
        {
            if (food.ToString() == "Meat")
            {
                Weight += food.Quantity * weightGain;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food}!");
            }
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
