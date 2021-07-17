namespace Bakery.Models.BakedFoods
{
    public class Cake : BakedFood
    {
        private const int portion = 245;

        public Cake(string name, decimal price) : base(name, portion, price)
        {
        }
    }
}