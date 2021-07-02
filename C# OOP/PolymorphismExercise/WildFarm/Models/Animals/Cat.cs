using System;

using WildFarm.Contracts;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double weightGain = 0.3;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override void Eat(Food food)
        {
            if (food.ToString() == "Meat" || food.ToString() == "Vegetable")
            {
                Weight += food.Quantity * weightGain;

                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food}!");
            }
        }
    }
}
