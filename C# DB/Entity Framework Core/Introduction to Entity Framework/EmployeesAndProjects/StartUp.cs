namespace EmployeesAndProjects
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using SoftUni.Data;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();

            string result = GetEmployeesInPeriod(context);

            Console.WriteLine(result);
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(x => x.EmployeesProjects
                    .Any(x => x.Project.StartDate.Year >= 2001
                              && x.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    MangerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                        .Select(p => p.Project)
                })
                .Take(10)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} - Manager: {employee.MangerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    string projectName = project.Name;
                    string startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    string endDate = project.EndDate is null
                        ? "not finished"
                        : project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    sb.AppendLine($"--{projectName} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
