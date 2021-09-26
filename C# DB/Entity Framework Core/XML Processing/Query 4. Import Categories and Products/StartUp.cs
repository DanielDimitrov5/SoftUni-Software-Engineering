using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
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

            string xml = File.ReadAllText("Datasets/categories-products.xml");

            string result = ImportCategoryProducts(context, xml);

            Console.WriteLine(result);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            var reader = new StringReader(inputXml);

            var categoryProductDtos = (ImportCategoryProductDto[])serializer.Deserialize(reader);

            var categoryProducts = categoryProductDtos
                .Select(x => new CategoryProduct
                {
                    CategoryId = x.CategoryId,
                    ProductId = x.ProductId
                })
                .ToList();

            foreach (var categoryProduct in categoryProducts)
            {
                bool IdsExist = context.Categories.Any(x => x.Id == categoryProduct.CategoryId) &&
                                context.Products.Any(x => x.Id == categoryProduct.ProductId);

                if (IdsExist)
                {
                    context.CategoryProducts.Add(categoryProduct);
                }
            }

            var count = context.SaveChanges();

            return $"Successfully imported {count}";
        }
    }
}