using System.IO;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("../../../input.txt");

            using (reader)
            {
                var line = reader.ReadLine();

                var writer = new StreamWriter("../../../output.txt");

                int counter = 0;

                using (writer)
                {
                    while (line != null)
                    {
                        counter++;

                        if (counter % 2 == 0)
                        {
                            writer.WriteLine(line);
                        }

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
