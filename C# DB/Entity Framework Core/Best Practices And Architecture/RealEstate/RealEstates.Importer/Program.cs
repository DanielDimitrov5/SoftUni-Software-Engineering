namespace RealEstates.Importer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Diagnostics;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using RealEstates.Data;
    using RealEstates.Models;
    using RealEstates.Services;
    class Program
    {
        static void Main()
        {
            Console.InputEncoding = Encoding.Unicode;

            //ImportJson("imot.bg-raw-data-2021-03-18.json");
            //ImportJson("imot.bg-houses-Sofia-raw-data-2021-03-18.json");
            //AddTags();
        }

        //private static void HouseTagImporter()
        //{
        //    var context = new RealEstateContext();

        //    var houses = context.Properties.Where(x => x.PropertyType.Name == "Къща").ToList();

        //    foreach (var house in houses)
        //    {
        //        house.Tags.Clear();

        //        house.AddTag(new Tag(){Name = "Къща"});
        //    }
        //}

        private static void ImportJson(string jsonFile)
        {
            var context = new RealEstateContext();

            IPropertiesService service = new PropertiesService(context);

            var json = File.ReadAllText(jsonFile);

            var properties = JsonSerializer.Deserialize<IEnumerable<PropertyAsJson>>(json);

            foreach (var property in properties)
            {
                service.Add
                    (property.District, property.Price, property.Floor, property.TotalFloors, property.Size,
                    property.YardSize, property.Year, property.Type, property.BuildingType);
            }
        }

        private static void AddTags()
        {
            var context = new RealEstateContext();

            var tags = new Dictionary<int, Tag>
            {
                {1, new Tag {Name = "Ново строителство"}},
                {2, new Tag {Name = "Старо строителство"}},
                {3, new Tag {Name = "Евтино строителство"}},
                {4, new Tag {Name = "Скъпо строителство"}},
                {5, new Tag {Name = "Къща"}},
                {6, new Tag {Name = "Апартамент"}},
                {7, new Tag {Name = "Топ оферта"}}
            };

            var properties = context.Properties.Include(x => x.BuildingType)
                                               .Include(x => x.PropertyType)
                                               .Include(x => x.District)
                                               .ToList();

            Stopwatch stopwatch = new Stopwatch();

            foreach (var property in properties)
            {
                stopwatch.Start();

                if (property.Price <= 0 || property.Size <= 0)
                {
                    continue;
                }

                /*
                Ново строителство
                Старо строителство
                Евтино имущество
                Скъпо имущество
                Къща
                Апартамент
                Топ оферта
                 */

                if (property.BuildingYear >= 2010)
                {
                    property.AddTag(tags[1]);
                }
                else
                {
                    property.AddTag(tags[2]);
                }

                var service = new DistrictService(context);

                var district = service.DistrictWithAveragePricePerSquareMeter()
                    .FirstOrDefault(x => x.DistrictId == property.DistrictId);

                decimal pricePerSquareMeter = property.Price / (decimal)property.Size;
                decimal districtAveragePricePerSquareMeter = district.AveragePricePerSquareMeter;

                if (pricePerSquareMeter + 100 < districtAveragePricePerSquareMeter)
                {
                    property.AddTag(tags[3]);
                }
                else if (pricePerSquareMeter - 50 > districtAveragePricePerSquareMeter)
                {
                    property.AddTag(tags[4]);
                }

                if (property.BuildingType.Name == "КЪЩА")
                {
                    property.AddTag(tags[5]);
                }
                else
                {
                    property.AddTag(tags[6]);
                }

                if (property.District.Properties.Count >= 10)
                {

                    var topCheapestPropertiesInDistrict = property
                        .District
                        .Properties
                        .ToList()
                        .Where(x => x.Price != 0)
                        .OrderBy(x => x.Price / (decimal)x.Size)
                        .Take(3);

                    if (topCheapestPropertiesInDistrict.Any(x => x.Id == property.Id))
                    {
                        property.AddTag(tags[7]);
                    }
                }

                context.SaveChanges();
            }

            stopwatch.Stop();
            Console.WriteLine($"Data imported for: " + stopwatch.Elapsed); // ~3:30:00 on my PC
        }
    }
}
