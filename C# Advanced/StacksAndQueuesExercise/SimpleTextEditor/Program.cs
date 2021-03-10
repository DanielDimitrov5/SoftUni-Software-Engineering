namespace SimpleTextEditor
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder word = new StringBuilder();

            Stack<string> commandStack = new Stack<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                int command = int.Parse(input[0]);

                switch (command)
                {
                    case 1:

                        commandStack.Push(word.ToString());

                        for (int j = 1; j < input.Length; j++)
                        {
                            string textToAppend = input[j];

                            word.Append(textToAppend);
                        }

                        break;
                    case 2:

                        int elementsToErase = int.Parse(input[1]);

                        commandStack.Push(word.ToString());

                        word = new StringBuilder(word.ToString().Substring(0, word.ToString().Length - elementsToErase));

                        break;
                    case 3:

                        int index = int.Parse(input[1]) - 1;

                        char ch = word[index];

                        Console.WriteLine(ch);

                        break;
                    case 4:

                        word.Clear();

                        word.Append(commandStack.Pop());

                        break;
                }
            }
        }
    }
}