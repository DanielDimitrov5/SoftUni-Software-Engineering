using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            string xml = File.ReadAllText("Datasets/users.xml");

            string result = ImportUsers(context, xml);

            Console.WriteLine(result);

        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            using (var reader = new StringReader(inputXml))
            {
                var usersDtos = (ImportUserDto[])serializer.Deserialize(reader);

                var users = usersDtos
                    .Select(x => new User
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Age = x.Age
                    })
                    .ToList();

                context.Users.AddRange(users);

                var count = context.SaveChanges();

                return $"Successfully imported {count}";
            }
        }
    }
}