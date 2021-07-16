using System.IO;

namespace AquaShop.IO
{
    using System;

    using AquaShop.IO.Contracts;

    public class Writer : IWriter
    {
        public Writer()
        {
            using (var writer = new StreamWriter("../../../output.txt"))
            {
                writer.Write("");
            }

        }
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            using (var writer = new StreamWriter("../../../output.txt", true))
            {
                writer.WriteLine(message);
            }
                //Console.WriteLine(message);
        }
    }
}
