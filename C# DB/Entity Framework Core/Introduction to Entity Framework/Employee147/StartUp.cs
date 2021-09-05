namespace Employee147
{
    using System;
    using System.Linq;
    using System.Text;
    using SoftUni.Data;
    using SoftUni.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();

            string result = GetEmployee147(context);

            Console.WriteLine(result);
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Employee employee = context.Employees.FirstOrDefault(x => x.EmployeeId == 147);

            var projects = context.EmployeesProjects
                .Select(x => new
                {
                    x.Project,
                    x.Employee.EmployeeId
                })
                .Where(x => x.EmployeeId == employee.EmployeeId)
                .OrderBy(x => x.Project.Name);

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in projects)
            {
                sb.AppendLine(project.Project.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }

}
