namespace SoftUni
{
    using System;
    using System.Linq;
    using System.Text;
    using SoftUni.Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();

            string result = GetEmployeesFullInformation(context);

            Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var data = context.Employees
                .Select(x => new { x.FirstName, x.LastName, x.MiddleName, x.JobTitle, x.Salary, x.EmployeeId })
                .OrderBy(x => x.EmployeeId)

            foreach (var record in data)
            {
                sb.AppendLine(
                    $"{record.FirstName} {record.LastName} {record.MiddleName} {record.JobTitle} {record.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}