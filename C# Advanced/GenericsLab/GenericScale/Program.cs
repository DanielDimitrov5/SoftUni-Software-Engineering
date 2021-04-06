using System;
using System.Collections.Generic;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<string> scale = new EqualityScale<string>("Pesho", "Pesho");

            Console.WriteLine(scale.AreEqual());
        }
    }
}
