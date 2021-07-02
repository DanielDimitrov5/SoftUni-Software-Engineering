using System;

using WildFarm.Contracts;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double weightGain = 0.1;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food.ToString() == "Vegetable" || food.ToString() == "Fruit")
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
            return "Squeak";
        }
    }
}
