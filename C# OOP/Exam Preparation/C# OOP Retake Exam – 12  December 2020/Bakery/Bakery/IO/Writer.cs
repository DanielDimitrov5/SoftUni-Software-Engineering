using System.IO;

namespace Bakery.IO
{
    using Bakery.IO.Contracts;
    using System;

    public class Writer : IWriter
    {
        public Writer()
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            {
                writer.Write(""); 
            }
        }
        public void Write(string message)
        {
            //Console.Write(message);
            using (StreamWriter writer = new StreamWriter("../../../output.txt", true))
            {
                writer.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            //Console.WriteLine(message);
            using (StreamWriter writer = new StreamWriter("../../../output.txt", true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
