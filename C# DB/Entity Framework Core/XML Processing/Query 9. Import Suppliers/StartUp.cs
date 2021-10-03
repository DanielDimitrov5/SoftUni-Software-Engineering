using System;
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

            string xml = File.ReadAllText("Datasets/suppliers.xml");

            string output = ImportSuppliers(context, xml);

            Console.WriteLine(output);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSupplier[]), new XmlRootAttribute("Suppliers"));

            var reader = new StringReader(inputXml);

            var supplierDto = (ImportSupplier[])serializer.Deserialize(reader);

            var suppliers = supplierDto.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter
            })
                .ToArray();

            context.Suppliers.AddRange(suppliers);

            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }
    }
}