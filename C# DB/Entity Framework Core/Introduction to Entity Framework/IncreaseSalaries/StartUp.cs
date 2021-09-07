namespace SoftUni
{
    using System;
    using System.Linq;
    using System.Text;
    using SoftUni.Data;
    using SoftUni.Models;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();

            string result = IncreaseSalaries(context);

            Console.WriteLine(result);
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Func<Employee, bool> departmentCheck = x => x.Department.Name == "Engineering" ||
                                                        x.Department.Name == "Tool Design" ||
                                                        x.Department.Name == "Marketing" ||
                                                        x.Department.Name == "Information Services";

            var employees = context.Employees
                .Include(x => x.Department)
                .Where(departmentCheck)
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            employees.ForEach(x => x.Salary *= 1.12m);

            context.SaveChanges();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }
    }
}