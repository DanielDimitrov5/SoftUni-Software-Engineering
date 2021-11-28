using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using SoftJail.DataProcessor;
using TeisterMask.DataProcessor.ExportDto;

namespace TeisterMask.DataProcessor
{
    using System;

    using Data;

    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            ExportProjectDto[] projects = context.Projects
                .Where(x => x.Tasks.Any())
                .ToArray()
                .Select(x => new ExportProjectDto()
                {
                    TasksCount = x.Tasks.Count.ToString(),
                    ProjectName = x.Name,
                    HasEndDate = x.DueDate is null ? "No" : "Yes",
                    Tasks = x.Tasks.Select(t => new ExportTaskDto()
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString()
                    })
                        .OrderBy(o => o.Name)
                        .ToArray()
                })
                .OrderByDescending(o => o.Tasks.Length)
                .ThenBy(o => o.ProjectName)
                .ToArray();

            var xml = XmlConverter.Serialize(projects, "Projects");

            return xml;
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(x => x.EmployeesTasks
                    .Select(t => t.Task)
                    .Any(d => d.OpenDate >= date))
                .ToArray()
                .Select(x => new
                {
                    Username = x.Username,
                    Tasks = x.EmployeesTasks.Select(t => t.Task).Where(d => d.OpenDate >= date).Select(s => new
                    {
                        TaskName = s.Name,
                        OpenDate = s.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = s.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = s.LabelType.ToString(),
                        ExecutionType = s.ExecutionType.ToString()
                    })
                        .OrderByDescending(o =>
                            DateTime.ParseExact(o.DueDate, "MM/dd/yyyy", CultureInfo.InvariantCulture))
                        .ThenBy(o => o.TaskName)
                })
                .OrderByDescending(o => o.Tasks.Count())
                .ThenBy(x => x.Username)
                .Take(10);

            var json = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return json;
        }
    }
}