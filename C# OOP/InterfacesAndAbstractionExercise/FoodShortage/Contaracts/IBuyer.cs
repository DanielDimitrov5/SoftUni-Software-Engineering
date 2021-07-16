namespace FoodShortage
{
    public interface IBuyer
    {
        public string Name { get; }
        public int Food { get; }
        
        void BuyFood();
    }
}
