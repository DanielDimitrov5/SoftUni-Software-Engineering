using System;
using System.Dynamic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());
            double finaleAssessment = 0.0;
            double presenatotions = 0.0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Finish")
                {
                    break;
                }

                presenatotions++;

                double totalGrade = 0.0;

                for (int i = 0; i < jury; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    totalGrade += grade;
                    
                    if (i == jury - 1)
                    {
                        finaleAssessment += totalGrade;
                        Console.WriteLine($"{input} - {totalGrade / jury:f2}.");
                        break;
                    }
                }
            }
            Console.WriteLine($"Student's final assessment is {finaleAssessment / (presenatotions * jury):f2}.");
        }
    }
}
