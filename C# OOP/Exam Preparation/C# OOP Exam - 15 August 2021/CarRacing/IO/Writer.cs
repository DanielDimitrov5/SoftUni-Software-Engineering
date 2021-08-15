using System.IO;

namespace CarRacing.IO
{
    using System;
    using Contracts;

    public class Writer : IWriter
    {
        public Writer()
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt", false))
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
            using (StreamWriter writer = new StreamWriter("../../../output.txt", true))
            {
                writer.WriteLine(message);
            }

            Console.WriteLine(message);
        }
    }
}
