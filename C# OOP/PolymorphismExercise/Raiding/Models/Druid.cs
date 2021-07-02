using Raiding.Contracts;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name) 
            : base(name)
        {
            Power = 80;
        }


        public override string CastAbility()
        {
            return base.CastAbility() + $" healed for {Power}";
        }
    }
}
