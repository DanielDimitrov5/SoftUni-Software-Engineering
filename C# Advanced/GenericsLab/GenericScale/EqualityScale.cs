using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        T first;
        T second;

        public EqualityScale(T first, T second)
        {
            this.first = first;
            this.second = second;
        }

        public bool AreEqual()
        {
            if (first.Equals(second))
            {
                return true;
            }

            return false;
        }
    }
}
