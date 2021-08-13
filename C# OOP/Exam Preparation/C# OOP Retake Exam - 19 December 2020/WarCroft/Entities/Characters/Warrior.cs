using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters.Contracts
{
    public class Warrior : Character, IAttacker
    {
        private const double health = 100;
        private const double armor = 50;
        private const double abilityPoints = 40;

        public Warrior(string name) : base(name, health, armor, abilityPoints, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            this.EnsureAlive();

            if (this == character)
            {
                throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);    
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}