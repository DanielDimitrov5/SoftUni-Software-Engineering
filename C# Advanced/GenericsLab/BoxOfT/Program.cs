namespace BoxOfT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            box.Add(1);
            box.Add(2);
            box.Add(4);

            Console.WriteLine(box.Remove());
            Console.WriteLine(box.Remove());
            Console.WriteLine(box.Remove());
        }
    }
}
