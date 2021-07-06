using System;
using System.Linq;
using System.Reflection;

using CommandPattern.Core.Contracts;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public CommandInterpreter()
        {
        }

        public string Read(string args)
        {
            string[] tokens = args.Split();

            string commandName = tokens[0];

            string[] arguments = args.Split().Skip(1).ToArray();

            Type assembly = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == $"{commandName}Command");

            ICommand instance = (ICommand)Activator.CreateInstance(assembly);

            return instance.Execute(arguments);
        }
    }
}