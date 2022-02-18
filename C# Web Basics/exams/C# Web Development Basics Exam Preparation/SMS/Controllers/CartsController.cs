using MyWebServer.Controllers;
using MyWebServer.Http;
using SMS.Services;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartService cartService;

        public CartsController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public HttpResponse AddProduct(string productId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            cartService.AddProductToCart(User.Id, productId);

            return Redirect("Details");
        }

        public HttpResponse Details()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            string cartId = cartService.GetCartIdByUserId(User.Id);

            var model = cartService.GetAllProductsInCart(cartId);

            return View(model);
        }

        public HttpResponse Buy()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/User/Login");
            }

            cartService.DeleteProductsInCart(User.Id);

            return Redirect("/");
        }
    }
}
