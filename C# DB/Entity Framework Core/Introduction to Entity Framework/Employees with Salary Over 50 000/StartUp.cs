using SoftUni.Data;

namespace Employees_with_Salary_Over_50_000
{
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();

            string result = GetEmployeesWithSalaryOver50000(context);

            Console.WriteLine(result);
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(x => x.Salary > 50000)
                .Select(e => new { e.FirstName, e.Salary })
                .OrderBy(x => x.FirstName).ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
