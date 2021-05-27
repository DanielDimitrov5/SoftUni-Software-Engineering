using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Contracts
{
    public interface ICallable
    {
        void Call(string phoneNumber);
    }
}
