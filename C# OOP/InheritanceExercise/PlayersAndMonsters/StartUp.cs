namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hero hero = new MuseElf("Ivo", 101);

            System.Console.WriteLine(hero);
        }
    }
}