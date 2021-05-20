using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliteters)
            : base (name, price)
        {
            Milliliters = milliliteters;
        }

        public double Milliliters { get; set; }
    }
}
