using System;
using System.Threading.Tasks;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int poorGrades = int.Parse(Console.ReadLine());
            double taskCount = 0;
            double totalGrade = 0;
            int poorGradesCount = 0;
            string lastTask = string.Empty;

            while (true)
            {
                string task = Console.ReadLine();
                if (task == "Enough")
                {
                    Console.WriteLine($"Average score: {totalGrade / taskCount:f2}");
                    Console.WriteLine($"Number of problems: {taskCount}");
                    Console.WriteLine($"Last problem: {lastTask}");
                    break;
                }
                taskCount++;
                lastTask = task;
                int grade = int.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    poorGradesCount++;
                }

                totalGrade += grade;

                if (poorGradesCount >= poorGrades)
                {
                    Console.WriteLine($"You need a break, {poorGrades} poor grades.");
                    break;
                }
            }
        }
    }
}
