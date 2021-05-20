using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double grams = 250;
        private const double calories = 100;
        private const decimal price = 5m;

        public Cake(string name)
            : base(name, price, calories, grams)
        {

        }
    }
}
