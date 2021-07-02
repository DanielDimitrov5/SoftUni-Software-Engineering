using System;
namespace Raiding.Contracts
{
    public abstract class BaseHero
    {
        public string Name { get; }
        public int Power { get; set; }

        public BaseHero(string name)
        {
            Name = name;
        }

        public virtual string CastAbility()
        {
            return $"{GetType().Name} - {Name}";
        }
    }
}
