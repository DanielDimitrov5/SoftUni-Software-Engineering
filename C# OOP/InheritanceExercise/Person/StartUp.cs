namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = System.Console.ReadLine();
            int age = int.Parse(System.Console.ReadLine());

            Person person = new Person(name, age);

            System.Console.WriteLine(person);
        }
    }
}