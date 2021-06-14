using FoodShortage.Core;
using System;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
