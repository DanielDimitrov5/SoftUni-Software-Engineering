using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal price = 3.5m;
        private const double milliliters = 50;

        public Coffee(string name, double caffeine)
            :base (name, price, milliliters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
