using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Models;
using SMS.Services;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public HttpResponse Create()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Create(ProductInputModel model)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            if (model.Name.Length < 4 || model.Name.Length > 20)
            {
                return Error("Product name should be between 4 and 20 characters!");
            }

            if (model.Price < 0.05m || model.Price > 1000m)
            {
                return Error("Product price should be between $0.05 and $1000 ");
            }

            productService.CreateProduct(model.Name, model.Price);

            return Redirect("/");
        }


    }
}
