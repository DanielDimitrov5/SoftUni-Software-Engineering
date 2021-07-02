namespace WildFarm.Contracts
{
    public abstract class Food
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
