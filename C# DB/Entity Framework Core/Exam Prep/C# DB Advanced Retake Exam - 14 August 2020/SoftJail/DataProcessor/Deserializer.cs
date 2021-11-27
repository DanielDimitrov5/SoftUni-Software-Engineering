using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Newtonsoft.Json;
using SoftJail.Data.Models;
using SoftJail.Data.Models.Enums;
using SoftJail.DataProcessor.ImportDto;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<Department> departments = new List<Department>();

            var departmentCells = JsonConvert.DeserializeObject<IEnumerable<DepartmentCellsDTO>>(jsonString);

            foreach (var departmentCellsDto in departmentCells)
            {
                if (!IsValid(departmentCellsDto) || !departmentCellsDto.Cells.All(IsValid) || !departmentCellsDto.Cells.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department department = new Department()
                {
                    Name = departmentCellsDto.Name,
                    Cells = departmentCellsDto.Cells.Select(x => new Cell()
                    {
                        CellNumber = x.CellNumber,
                        HasWindow = x.HasWindow
                    }).ToList()
                };

                departments.Add(department);

                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            List<Prisoner> prisoners = new List<Prisoner>();

            var prisonersMails = JsonConvert.DeserializeObject<IEnumerable<PrisonersMailsDTO>>(jsonString);

            foreach (var prisonersMailsDto in prisonersMails)
            {
                if (!IsValid(prisonersMailsDto) || !prisonersMailsDto.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isValidReleaseDate = DateTime.TryParseExact(
                    prisonersMailsDto.ReleaseDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime releaseDate);


                var incarcerationDate = DateTime.ParseExact(
                    prisonersMailsDto.IncarcerationDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture);


                Prisoner prisoner = new Prisoner()
                {
                    FullName = prisonersMailsDto.FullName,
                    Nickname = prisonersMailsDto.Nickname,
                    Age = prisonersMailsDto.Age,
                    ReleaseDate = isValidReleaseDate ? (DateTime?)releaseDate : null,
                    IncarcerationDate = incarcerationDate,
                    Bail = prisonersMailsDto.Bail,
                    CellId = prisonersMailsDto.CellId,
                    Mails = prisonersMailsDto.Mails.Select(x => new Mail()
                    {
                        Description = x.Description,
                        Sender = x.Sender,
                        Address = x.Address
                    }).ToArray()
                };

                prisoners.Add(prisoner);

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            List<Officer> officers = new List<Officer>();

            var officersDtos = XmlConverter.Deserializer<OfficerPrisonerDTO>(xmlString, "Officers");

            foreach (var officerPrisonerDto in officersDtos)
            {
                if (!IsValid(officerPrisonerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Officer officer = new Officer()
                {
                    FullName = officerPrisonerDto.Name,
                    Salary = officerPrisonerDto.Money,
                    DepartmentId = officerPrisonerDto.DepartmentId,
                    Position = Enum.Parse<Position>(officerPrisonerDto.Position),
                    Weapon = Enum.Parse<Weapon>(officerPrisonerDto.Weapon),
                    OfficerPrisoners = officerPrisonerDto.Prisoners.Select(x => new OfficerPrisoner()
                    {
                        PrisonerId = x.Id
                    })
                        .ToList()
                };

                //officers.Add(officer);

                context.Officers.Add(officer);
                context.SaveChanges();

                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            //context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}