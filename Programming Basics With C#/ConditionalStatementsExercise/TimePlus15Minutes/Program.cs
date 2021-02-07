using System;

namespace TimePlus15Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int result = minutes + 15;
            
            if (result > 59)
            {
                hours = hours + 1;
                minutes = result - 60;
            }
            else
            {
                minutes = result;
            }
            if (hours == 24)
            {
                hours = 0;
            }
            if (minutes < 10)
            {
                Console.WriteLine($"{hours}:0{minutes}");
            }
            else
            {
                Console.WriteLine($"{hours}:{minutes}");
            }
            
            
            
            


        }
    }
}
