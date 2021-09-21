using System;
using System.Collections.Generic;
using System.IO;
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

            var json = File.ReadAllText("../../../Datasets/sales.json");

            Console.WriteLine(ImportSales(context, json));
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var data = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(data);

            context.SaveChanges();

            return $"Successfully imported {data.Count()}.";
        }
    }
}