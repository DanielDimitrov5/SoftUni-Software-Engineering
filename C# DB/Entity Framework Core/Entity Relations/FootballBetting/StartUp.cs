using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    using System;

     public class StartUp
    {
        public static void Main(string[] args)
        {
            FootballBettingContext context = new FootballBettingContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
