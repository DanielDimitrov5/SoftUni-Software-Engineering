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

            var json = File.ReadAllText("../../../Datasets/customers.json");

            Console.WriteLine(ImportCustomers(context, json));
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var data = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(data);

            context.SaveChanges();

            return $"Successfully imported {data.Count()}.";
        }
    }
}