using System;
using System.Linq;
using System.Text;
using SoftUni.Data;

namespace EmployeesFromResearchAndDevelopment
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();

            string result = GetEmployeesFromResearchAndDevelopment(context);

            Console.WriteLine(result);
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x => new {x.FirstName, x.LastName, x.Department.Name, x.Salary})
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName);

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
