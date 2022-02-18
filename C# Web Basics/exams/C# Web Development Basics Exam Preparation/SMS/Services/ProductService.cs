using SMS.Data;
using SMS.Models;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly SMSDbContext context;

        public ProductService(SMSDbContext context)
        {
            this.context = context;
        }

        public void CreateProduct(string name, decimal price)
        {
            Product product = new Product
            {
                Name = name,
                Price = price,
            };

            context.Products.Add(product);

            context.SaveChanges();
        }

        public ICollection<ProductViewModel> GetAllProducts()
        {
            var products = context.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price.ToString(),
            })
                .ToArray();

            return products;
        }

        public LoggedInIndexViewModel GetIndexViewModel(string currentUsername)
        {
            var model = new LoggedInIndexViewModel
            {
                Username = currentUsername,
                Products = GetAllProducts(),
            };

            return model;
        }
    }
}
