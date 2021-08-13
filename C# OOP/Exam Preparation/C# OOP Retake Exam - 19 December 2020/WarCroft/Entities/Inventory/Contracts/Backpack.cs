namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int capacity = 100;

        public Backpack() : base(capacity)
        {
        }
    }
}