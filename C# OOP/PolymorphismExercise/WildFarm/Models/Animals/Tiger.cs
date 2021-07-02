using System;
using WildFarm.Contracts;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double weightGain = 1;

        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
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
            return "ROAR!!!";
        }

    }
}
