using System;

namespace _2._Passed
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            if (grade >= 3d)
            {
                Console.WriteLine("Passed!");
            }
        }
    }
}
