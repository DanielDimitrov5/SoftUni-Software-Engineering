using System;

namespace DataModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int diff = DataMadifier.DiffCalcularor(firstDate, secondDate);

            Console.WriteLine(diff);
        }
    }
}
