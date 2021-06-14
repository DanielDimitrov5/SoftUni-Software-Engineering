using BorderControl.Contracts;
using BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl.Core
{
    public class Engine
    {
        private readonly List<IIdentifiable> identifiables;

        public Engine()
        {
            identifiables = new List<IIdentifiable>();
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split();

                if (data.Length == 2)
                {
                    AddRobot(data);
                }
                else if (data.Length == 3)
                {
                    AddCitizen(data);
                }
            }

            string fakeIds = Console.ReadLine();

            foreach (var item in identifiables.Where(x => x.Id.EndsWith(fakeIds)))
            {
                Console.WriteLine(item.Id);
            }
        }

        private void AddRobot(string[] data)
        {
            string model = data[0];
            string id = data[1];

            IIdentifiable robot = new Robot(model, id);

            identifiables.Add(robot);
        }

        private void AddCitizen(string[] data)
        {
            string name = data[0];
            int age = int.Parse(data[1]);
            string id = data[2];

            IIdentifiable citizen = new Citizen(name, age, id);

            identifiables.Add(citizen);
        }
    }
}