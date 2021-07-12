using System;
using System.Linq;
using System.Collections.Generic;
using Raiding.Contracts;

namespace Raiding.Core
{
    public class Engine
    {
        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> raidGroup = new List<BaseHero>(n);

            while (raidGroup.Count < n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                Type heroType = Type.GetType($"Raiding.Models.{type}");

                if (heroType == null)
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                BaseHero hero = (BaseHero)Activator.CreateInstance(heroType, name);
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
