using System;

using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private ICommandInterpreter command;

        public Engine(ICommandInterpreter command)
        {
            this.command = command;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();

                string output = command.Read(input);

                Console.WriteLine(output);
            }
        }
    }
}