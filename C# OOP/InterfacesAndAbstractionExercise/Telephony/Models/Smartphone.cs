using System;
using System.Linq;
using Telephony.Contracts;

namespace Telephony.Models
{
    public class Smartphone : ICallable,  IBrowsable
    {
        public void Call(string phoneNumber)
        {
            if (phoneNumber.All(x => char.IsDigit(x)))
            {
                Console.WriteLine($"Calling... {phoneNumber}");
            }
            else
            {
                throw new ArgumentException(ExeptionsMessages.InvalidNumberExeptionMessage);
            }
        }

        public void Browse(string site)
        {
            if (site.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException(ExeptionsMessages.InvalidUrlExeptionMessage);
            }

            Console.WriteLine($"Browsing: {site}!");
        }
    }
}
