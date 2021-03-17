using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studetnsRecord = new Dictionary<string, List<decimal>>(n);

            for (int i = 0; i < n; i++)
            {
                string[] studentData = Console.ReadLine().Split();

                string name = studentData[0];
                decimal grade = decimal.Parse(studentData[1]);

                if (studetnsRecord.ContainsKey(name) == false)
                {
                    studetnsRecord.Add(name, new List<decimal>());
                }

                studetnsRecord[name].Add(grade);
            }

            foreach (var student in studetnsRecord)
            {
                Console.Write($"{student.Key} -> ");

                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:F2} ");
                }

                Console.WriteLine($"(avg: {student.Value.Average():F2})");
            }
        }
    }
}
