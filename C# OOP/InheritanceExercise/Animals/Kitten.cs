using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender) : base(name, age, gender)
        {
            Gender = "Female";
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
        public override string ToString()
        {
            return "Kitten";
        }
    }
}
