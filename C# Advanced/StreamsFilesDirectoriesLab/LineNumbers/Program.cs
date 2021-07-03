using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("../../../input.txt");

            using (reader)
            {
                string line = reader.ReadLine();

                var writer = new StreamWriter("../../../output.txt");

                using (writer)
                {
                    int row = 0;

                    while (line != null)
                    {
                        writer.WriteLine($"{++row}. {line}");

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
