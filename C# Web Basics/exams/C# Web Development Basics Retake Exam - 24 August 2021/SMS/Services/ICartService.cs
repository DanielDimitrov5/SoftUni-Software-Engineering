using SMS.Models;
using System.Collections.Generic;

namespace SMS.Services
{
    public interface ICartService
    {
        void AddProductToCart(string userId, string productId);

        ICollection<ProductViewModel> GetAllProductsInCart(string userId);

        string GetCartIdByUserId(string userId);

        void DeleteProductsInCart(string userId);
    }
}
