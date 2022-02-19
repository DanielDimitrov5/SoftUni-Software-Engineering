using SMS.Data;
using SMS.Models;
using System.Collections.Generic;
using System.Linq;

namespace SMS.Services
{
    public class CartService : ICartService
    {
        private readonly SMSDbContext context;
        private readonly IUserService userService;

        public CartService(SMSDbContext context, IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }

        public void AddProductToCart(string userId, string productId)
        {
            Product product = context.Products.FirstOrDefault(x=>x.Id == productId);

            if (product == null)
            {
                return;
            }

            User currentUser = context.Users.FirstOrDefault(x => x.Id == userId);

            context.Entry(currentUser).Reference(x => x.Cart).Load();

            currentUser.Cart.Products.Add(product);

            context.SaveChanges();
        }

        public void DeleteProductsInCart(string userId)
        {
            var productToDelete = context.Products.Where(x => x.Cart.UserId == userId);

            context.Products.RemoveRange(productToDelete);

            context.SaveChanges();
        }

        public ICollection<ProductViewModel> GetAllProductsInCart(string cartId)
        {
            return context.Products
                .Where(x => x.Cart.Id == cartId)
                .Select(x=> new ProductViewModel
            {
                Name = x.Name,
                Price = x.Price.ToString(),
            })
                .ToArray();
        }

        public string GetCartIdByUserId(string userId)
        {
            return context.Carts.FirstOrDefault(x => x.UserId == userId)?.Id;
        }
    }
}
