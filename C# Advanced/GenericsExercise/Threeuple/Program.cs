using System;
using Tuple;

namespace Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nameAddres = Console.ReadLine().Split(" ", 4);

            string name = $"{nameAddres[0]} {nameAddres[1]}";
            string addres = nameAddres[2];
            string town = nameAddres[3];

            Threeuple<string, string, string> nameAddresTown = new Threeuple<string, string, string>(name, addres, town);

            Console.WriteLine(nameAddresTown);

            string[] drunkData = Console.ReadLine().Split();

            string drunkName = drunkData[0];
            int beer = int.Parse(drunkData[1]);
            bool drunk = false;
            if (drunkData[2] == "drunk")
            {
                drunk = true;
            }

            Threeuple<string, int, bool> drunkMan = new Threeuple<string, int, bool>(drunkName, beer, drunk);

            Console.WriteLine(drunkMan);

            string[] bankData = Console.ReadLine().Split();

            string accountName = bankData[0];
            double balance = double.Parse(bankData[1]);
            string bank = bankData[2];

            Threeuple<string, double, string> bankAccount = new Threeuple<string, double, string>(accountName, balance, bank);

            Console.WriteLine(bankAccount);
        }
    }
}
