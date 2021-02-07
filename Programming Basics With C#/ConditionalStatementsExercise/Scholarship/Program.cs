using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double grade = double.Parse(Console.ReadLine());
            double minimumIncome = double.Parse(Console.ReadLine());
            double socialScholarship = Math.Floor(minimumIncome * 0.35);
            double highGradeScholarship = Math.Floor(grade * 25);

            if (grade >= 5.50 && income <= minimumIncome && highGradeScholarship >= socialScholarship)
            {
                Console.WriteLine($"You get a scholarship for excellent results {highGradeScholarship} BGN");
            }
            else if (grade >= 5.50 && income <= minimumIncome && highGradeScholarship < socialScholarship)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }
            else if (grade >= 5.50 && income >= minimumIncome)
            {
                Console.WriteLine($"You get a scholarship for excellent results {highGradeScholarship} BGN");
            }
            else if (grade > 4.50 && income < minimumIncome)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }

                    
        }
    }
}
