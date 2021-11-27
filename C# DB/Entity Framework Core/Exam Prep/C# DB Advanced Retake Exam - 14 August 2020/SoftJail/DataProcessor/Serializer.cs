using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SoftJail.DataProcessor.ExportDto;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(x => ids.Contains(x.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(y => new
                    {
                        OfficerName = y.Officer.FullName,
                        Department = y.Officer.Department.Name
                    })
                        .OrderBy(o => o.OfficerName)
                        .ToList(),
                    TotalOfficerSalary = decimal.Parse(x.PrisonerOfficers
                        .Sum(z => z.Officer.Salary)
                        .ToString("F2"))
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToList();

            var json = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] prisonersNamesArray = prisonersNames.Split(",", StringSplitOptions.RemoveEmptyEntries);

            PrisonerExportDTO[] prisoners = context.Prisoners
                .Where(x => prisonersNamesArray.Contains(x.FullName))
                .Select(x => new PrisonerExportDTO()
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = x.Mails.Select(y => new MessageDTO()
                    {
                        Description = String.Join("", y.Description.Reverse())
                    })
                        .ToArray()
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToArray();

            var xml = XmlConverter.Serialize(prisoners, "Prisoners");

            return xml;
        }
    }
}