using System;

namespace _6._Foreign_Languages
{
    class Program
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            switch (countryName)
            {
                case "England":
                    Console.WriteLine("English");
                    break;
                case "USA":
                    Console.WriteLine("English");
                    break;
                case "Spain":
                    Console.WriteLine("Spanish");
                    break;
                case "Argentina":
                    Console.WriteLine("Spanish");
                    break;
                case "Mexico":
                    Console.WriteLine("Spanish");
                    break;
               
                default:
                    Console.WriteLine("unknown");
                    break;
            }
        }
    }
}
