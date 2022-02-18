using SMS.Models;
using System.Collections.Generic;

namespace SMS.Services
{
    public interface IProductService
    {
        void CreateProduct(string name, decimal price);

        ICollection<ProductViewModel> GetAllProducts();

        LoggedInIndexViewModel GetIndexViewModel(string currentUsername);
    }
}
