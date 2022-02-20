namespace FootballManager
{
    using MyWebServer;
    using FootballManager.Data;
    using System.Threading.Tasks;
    using MyWebServer.Controllers;
    using MyWebServer.Results.Views;
    using Microsoft.EntityFrameworkCore;
    using FootballManager.Services;

    public class Startup
    {
        public static async Task Main()
            => await HttpServer
                .WithRoutes(routes => routes
                    .MapStaticFiles()
                    .MapControllers())
                .WithServices(services => services
                .Add<FootballManagerDbContext>()
                .Add<IViewEngine, CompilationViewEngine>()
                .Add<IUserService, UserService>()
                .Add<IPlayerService, PlayerService>())
                .WithConfiguration<FootballManagerDbContext>(context => context
                    .Database.Migrate())
                .Start();
    }
}
