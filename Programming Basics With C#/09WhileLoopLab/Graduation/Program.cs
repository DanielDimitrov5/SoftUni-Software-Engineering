using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            double grade = 1;
            double raitingCounter = 0;
            int failCounter = 0;

            //int rating = 0;

            while (grade <= 12)
            {
                double rating = double.Parse(Console.ReadLine());
                if (rating > 6 || rating < 2)
                {
                    Console.WriteLine($"Invalid grade - №{grade}!\nTry again :)");
                    break;
                }
                if (rating >= 4)
                {
                    grade++;
                    raitingCounter += rating;
                }
                else
                {
                    failCounter++;
                }
                if (failCounter > 1)
                {
                    Console.WriteLine($"{studentName} has been excluded at {grade} grade");
                    break;
                }
                if (grade > 12)
                {
                    Console.WriteLine($"{studentName} graduated. Average grade: {raitingCounter / 12:f2}");
                }
            }
        }
    }
}
