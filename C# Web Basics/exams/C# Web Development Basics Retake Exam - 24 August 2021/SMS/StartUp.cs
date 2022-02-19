using Microsoft.EntityFrameworkCore;
using SMS.Services;

namespace SMS
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;

    public class StartUp
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IUserService, UserService>()
                    .Add<IProductService, ProductService>()
                    .Add<ICartService, CartService>())
                    .Start();
    }
}