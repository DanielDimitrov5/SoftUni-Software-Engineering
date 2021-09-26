using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ProductShop.Data;
using ProductShop.Dtos.Export;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            string result = GetUsersWithProducts(context);

            Console.WriteLine(result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any())
                .Select(x => new ExportUserWithSoldProducts
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    ExportProductsCount = new ExportProductsCount
                    {
                        Count = x.ProductsSold.Count,
                        SoldProducts = x.ProductsSold.Select(p => new ExportSoldProductsDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                    }

                })
                .OrderByDescending(x => x.ExportProductsCount.Count)
                .Take(10)
                .ToArray();

            var usersWithProducts = new UserCountWithProductsDto
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                ExportUserWithSoldProducts = users
            };

            var writer = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlSerializer serializer = new XmlSerializer(typeof(UserCountWithProductsDto), new XmlRootAttribute("Users"));

            serializer.Serialize(writer, usersWithProducts, ns);

            return writer.GetStringBuilder().ToString();
        }
    }
}