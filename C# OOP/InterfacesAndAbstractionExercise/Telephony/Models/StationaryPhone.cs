using System;
using System.Linq;
using Telephony.Contracts;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public void Call(string phoneNumber)
        {
            if (phoneNumber.All(x => char.IsDigit(x)))
            {
                Console.WriteLine($"Dialing... {phoneNumber}");
            }
            else
            {
                throw new ArgumentException(ExeptionsMessages.InvalidNumberExeptionMessage);
            }
        }
    }
}
