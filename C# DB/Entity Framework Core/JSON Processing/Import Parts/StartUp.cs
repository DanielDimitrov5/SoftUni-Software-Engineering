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

            Console.WriteLine(ImportParts(context, json));
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var data = JsonConvert.DeserializeObject<Part[]>(inputJson);

            foreach (var part in data)
            {
                if (context.Suppliers.Select(x=>x.Id).Contains(part.SupplierId))
                {
                    context.Parts.Add(part);
                }
            }

            context.SaveChanges();

            return $"Successfully imported {context.Parts.Count()}.";
        }
    }
}