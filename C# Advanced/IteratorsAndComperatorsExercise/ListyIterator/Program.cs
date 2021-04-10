using System;

namespace ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var listCreater = Console.ReadLine().Split(new string[] { "Create", " " }, StringSplitOptions.RemoveEmptyEntries);

            ListyIterator<string> list = new ListyIterator<string>(listCreater);
            int g = list.Count;

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Move": Console.WriteLine(list.Move()); break;
                    case "Print": list.Print(); break;
                    case "HasNext": Console.WriteLine(list.HasNext()); break;
                    case "PrintAll":

                        foreach (var item in list)
                        {
                            Console.Write(item + " ");
                        }

                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
