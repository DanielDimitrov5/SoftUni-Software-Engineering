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

            var data = JsonConvert.DeserializeObject<Sale[]>(json);

            Console.WriteLine(ImportSuppliers(context, json));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var data = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(data);

            context.SaveChanges();

            return $"Successfully imported {data.Count()}.";
        }
    }
}