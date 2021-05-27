using System;
using System.Linq;
using System.Numerics;
using Telephony.Contracts;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        private string phoneNumber;
        private string site;

        public string PhoneNumber
        {
            get => phoneNumber;

            private set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException("Invalid number!");
                }

                phoneNumber = value;
            }
        }

        public string Site
        {
            get => site;

            private set
            {
                if (!BigInteger.TryParse(value, out BigInteger result))
                {
                    //!!!!
                }
            }
        }
        public void Call(string phoneNumber)
        {
            Console.WriteLine($"Calling... {phoneNumber}");
        }

        public void Browse(string site)
        {
            Console.WriteLine($"Browsing: {site}!");
        }
    }
}
