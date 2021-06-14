namespace FoodShortage
{
    public interface IBuyer
    {
        public string Name { get; set; }
        public int Food { get; }
        void BuyFood();
    }
}
