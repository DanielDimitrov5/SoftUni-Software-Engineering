namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int comfort = 1;
        private const decimal price = 5;

        public Ornament() : base(comfort, price)
        {
        }
    }
}