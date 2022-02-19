namespace SharedTrip
{
    using System.Threading.Tasks;

    using MyWebServer;
    using MyWebServer.Controllers;

    using MyWebServer.Results.Views;
    using SharedTrip.Services;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                    .Add<IViewEngine, CompilationViewEngine>()
                    .Add<IUserService, UserService>()
                    .Add<ITripService, TripService>())
                .Start();
    }
}
