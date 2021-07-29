using System.IO;

namespace EasterRaces.IO
{
    using System;

    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public ConsoleWriter() 
        {
            using (var writer = new StreamWriter("../../../output.txt"))
            {
                writer.WriteLine(string.Empty);
            }
        }

        public void WriteLine(string message)
        {
            using (var writer=  new StreamWriter("../../../output.txt", true))
            {
                writer.WriteLine(message);
            }

            //Console.WriteLine(message);
        }

        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}