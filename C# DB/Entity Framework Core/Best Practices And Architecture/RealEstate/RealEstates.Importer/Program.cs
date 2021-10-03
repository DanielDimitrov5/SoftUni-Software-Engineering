using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using RealEstates.Data;
using RealEstates.Services;

namespace RealEstates.Importer
{
    class Program
    {
        static void Main()
        {
            ImportJson("imot.bg-raw-data-2021-03-18.json");
            ImportJson("imot.bg-houses-Sofia-raw-data-2021-03-18.json");
        }

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
    }
}
