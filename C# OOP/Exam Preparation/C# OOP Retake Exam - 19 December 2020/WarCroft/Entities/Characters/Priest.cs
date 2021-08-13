using WarCroft.Entities.Items;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        private const double health = 50;
        private const double armor = 25;
        private const double abilityPoints = 40;

        public Priest(string name) : base(name, health, armor, abilityPoints, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            EnsureAlive();

            character.UseItem(new HealthPotion());
            character.UseItem(new HealthPotion());
        }
    }
}
