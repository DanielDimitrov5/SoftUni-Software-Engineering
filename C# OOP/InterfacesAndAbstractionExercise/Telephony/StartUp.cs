using System;
using Telephony.Models;

namespace Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            string[] phones = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var phone in phones)
            {
                try
                {
                    if (phone.Length == 7)
                    {
                        stationaryPhone.Call(phone);
                    }
                    else if (phone.Length == 10)
                    {
                        smartphone.Call(phone);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid number!");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

            }

            string[] sites = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (var site in sites)
            {
                try
                {
                    smartphone.Browse(site);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
