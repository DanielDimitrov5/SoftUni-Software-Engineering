using System;
using System.Collections.Generic;
using System.Linq;

using MilitaryElite.Contracts;
using MilitaryElite.Models;

namespace MilitaryElite.Core
{
    public class Engine
    {
        private readonly List<ISoldier> soldiers;

        public Engine()
        {
            soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string typeOfSoldier = input.Split(" ", 2)[0];

                string[] soldierInfo = input.Split().Skip(1).ToArray();

                string id = soldierInfo[0];
                string firstName = soldierInfo[1];
                string lastName = soldierInfo[2];

                if (typeOfSoldier == "Private")
                {
                    decimal salary = decimal.Parse(soldierInfo[3]);

                    Private @private = new Private(id, firstName, lastName, salary);

                    soldiers.Add(@private);
                }
                else if (typeOfSoldier == "Spy")
                {
                    int codeNumber = int.Parse(soldierInfo[3]);

                    Spy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiers.Add(spy);
                }
                else if (typeOfSoldier == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(soldierInfo[3]);

                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 4; i < soldierInfo.Length; i++)
                    {
                        string currentId = soldierInfo[i];

                        if (soldiers.Any(x => x.Id == currentId))
                        {
                            lieutenantGeneral.AddPrivate((IPrivate)soldiers.Find(x => x.Id == currentId));
                        }
                    }

                    soldiers.Add(lieutenantGeneral);
                }
                else if (typeOfSoldier == "Engineer")
                {
                    decimal salary = decimal.Parse(soldierInfo[3]);

                    if (soldierInfo[4] == "Airforces" || soldierInfo[4] == "Marines")
                    {
                        string corp = soldierInfo[4];

                        Engineer engineer = new Engineer(id, firstName, lastName, salary, corp);

                        for (int i = 5; i < soldierInfo.Length; i += 2)
                        {
                            string partName = soldierInfo[i];
                            int hoursWorked = int.Parse(soldierInfo[i + 1]);

                            Repair repair = new Repair(partName, hoursWorked);

                            engineer.AddRepair(repair);
                        }

                        soldiers.Add(engineer);
                    }
                }
                else if (typeOfSoldier == "Commando")
                {
                    decimal salary = decimal.Parse(soldierInfo[3]);

                    if (soldierInfo[4] == "Airforces" || soldierInfo[4] == "Marines")
                    {
                        string corp = soldierInfo[4];

                        Commando commando = new Commando(id, firstName, lastName, salary, corp);

                        for (int i = 5; i < soldierInfo.Length; i += 2)
                        {

                            if (soldierInfo[i + 1] == "Finished" || soldierInfo[i + 1] == "inProgress")
                            {
                                string codeName = soldierInfo[i];
                                string state = soldierInfo[i + 1];

                                Mission mission = new Mission(codeName, state);

                                commando.AddMission(mission);
                            }
                        }

                        soldiers.Add(commando);
                    }
                }
            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
