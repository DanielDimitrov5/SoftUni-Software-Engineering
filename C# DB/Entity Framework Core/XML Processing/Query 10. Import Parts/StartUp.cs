using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using CarDealer.Data;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            string xml = File.ReadAllText("Datasets/parts.xml");

            string output = ImportParts(context, xml);

            Console.WriteLine(output);
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPart[]), new XmlRootAttribute("Parts"));

            var reader = new StringReader(inputXml);

            var partDto = (ImportPart[])serializer.Deserialize(reader);

            foreach (var importPart in partDto)
            {
                if (context.Suppliers.Any(x => x.Id == importPart.SupplierId))
                {
                    Part part = new Part()
                    {
                        Name = importPart.Name,
                        Price = importPart.Price,
                        Quantity = importPart.Quantity,
                        SupplierId = importPart.SupplierId
                    };

                    context.Parts.Add(part);
                }
            }

            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }
    }
}