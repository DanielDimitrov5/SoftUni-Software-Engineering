namespace Bakery.Models.BakedFoods
{
    public class Bread : BakedFood
    {
        private const int portion = 200;

        public Bread(string name, decimal price) : base(name, portion, price)
        {
        }
    }
}