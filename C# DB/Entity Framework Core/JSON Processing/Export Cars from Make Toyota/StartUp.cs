using System;
using System.Globalization;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            Console.WriteLine(GetCarsFromMakeToyota(context));
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var data = context.Cars
                .Where(x => x.Make == "Toyota")
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance);

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            };

            var json = JsonConvert.SerializeObject(data, options);

            return json;
        }
    }
}