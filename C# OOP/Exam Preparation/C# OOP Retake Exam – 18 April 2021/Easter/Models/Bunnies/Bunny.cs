using System;
using System.Linq;

using Easter.Utilities.Messages;
using System.Collections.Generic;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Bunnies.Contracts;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;

        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            Dyes = new List<IDye>();
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                name = value;
            }
        }

        public int Energy { get; protected set; }

        public ICollection<IDye> Dyes { get; }

        public void AddDye(IDye dye)
        {
            Dyes.Add(dye);
        }

        public virtual void Work()
        {
            Energy -= 10;

            if (Energy <= 0)
            {
                Energy = 0;
            }
            else
            {
                while (Dyes.Any())
                {
                    if (Dyes.First().IsFinished() == false)
                    {
                        Dyes.First().Use();
                        break;
                    }

                    Dyes.Remove(Dyes.First());
                }
            }
        }
    }
}
