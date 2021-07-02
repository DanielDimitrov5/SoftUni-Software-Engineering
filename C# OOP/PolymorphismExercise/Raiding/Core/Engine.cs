using System;
using System.Linq;
using System.Collections.Generic;

using Raiding.Models;
using Raiding.Contracts;

namespace Raiding.Core
{
    public class Engine
    {
        public Engine()
        { }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> raidGroup = new List<BaseHero>(n);

            while (raidGroup.Count < n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                BaseHero hero = null;

                if (type == "Druid")
                {
                    hero = new Druid(name);
                }
                else if (type == "Paladin")
                {
                    hero = new Paladin(name);
                }
                else if (type == "Rogue")
                {
                    hero = new Rogue(name);
                }
                else if (type == "Warrior")
                {
                    hero = new Warrior(name);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                raidGroup.Add(hero);
            }

            foreach (BaseHero hero in raidGroup)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int bossPower = int.Parse(Console.ReadLine());

            int totalPower = raidGroup.Sum(x => x.Power);

            Console.WriteLine(totalPower >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
