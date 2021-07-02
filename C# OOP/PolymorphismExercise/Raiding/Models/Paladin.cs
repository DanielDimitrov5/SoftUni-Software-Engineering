using Raiding.Contracts;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name)
            : base(name)
        {
            Power = 100;
        }

        public override string CastAbility()
        {
            return base.CastAbility() + $" healed for {Power}";
        }
    }
}
