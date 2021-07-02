using Raiding.Contracts;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name)
            : base(name)
        {
            Power = 100;
        }

        public override string CastAbility()
        {
            return base.CastAbility() + $" hit for {Power} damage";
        }
    }
}
