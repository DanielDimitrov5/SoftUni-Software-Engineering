using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender) : base(name, age, gender)
        {
            Gender = "Male";
        }

        public override void ProduceSound()
        {
            Console.WriteLine("MEOW");
        }
        public override string ToString()
        {
            return "Tomcat";
        }
    }
}
