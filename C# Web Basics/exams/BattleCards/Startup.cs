using BattleCards.Data;
using BattleCards.Services;
using Microsoft.EntityFrameworkCore;

namespace BattleCards
{
    using System.Collections.Generic;

    using SIS.HTTP;
    using SIS.MvcFramework;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUserService, UserService>();
            serviceCollection.Add<ICardService, CardService>();
        }
    }
}
