using WildFarm.Contracts;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double weightGain = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            Weight += food.Quantity * weightGain;
            FoodEaten += food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
