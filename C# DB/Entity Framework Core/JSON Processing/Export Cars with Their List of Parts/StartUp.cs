using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            Console.WriteLine(GetCarsWithTheirListOfParts(context));
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var data = context.Cars
                .Select(x => new CarPartsDTO
                {
                    Car = new ExportCarDto
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance
                    },
                    Parts = x.PartCars
                        .Select(p => new ExportPartDTO
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price.ToString("F2")
                        })
                        .ToList()
                })
                .ToList();

            var options = new JsonSerializerSettings
            {
                ////Formatting = Formatting.Indented,
                //ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var json = JsonConvert.SerializeObject(data, options);

            return json;
        }
    }
}