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

            string xml = File.ReadAllText("Datasets/cars.xml");

            string output = ImportCars(context, xml);

            Console.WriteLine(output);
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCar[]), new XmlRootAttribute("Cars"));

            var reader = new StringReader(inputXml);

            var carDto = (ImportCar[])serializer.Deserialize(reader);

            foreach (var importCar in carDto)
            {
                Car car = new Car
                {
                    Make = importCar.Make,
                    Model = importCar.Model,
                    TravelledDistance = importCar.TravelledDistance
                };

                context.Cars.Add(car);

                var parts = importCar.Parts
                    .Distinct()
                    .Select(x => x.Id)
                    .ToArray();

                foreach (var part in parts)
                {
                    PartCar partCar = new PartCar
                    {
                        PartId = part,
                        CarId = car.Id
                    };

                    if (car.PartCars.FirstOrDefault(pc => pc.PartId == part) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();

            return $"Successfully imported {carDto.Length}";
        }
    }
}