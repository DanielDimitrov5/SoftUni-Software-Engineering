using System;
using System.IO;
using System.Linq;

namespace CustomLog.Loggers
{
    public class LogFile : ILogFile
    {
        private const string filePath = "../../../log.txt";

        public int Size => File.ReadAllText(filePath).Where(x => char.IsLetter(x)).Sum(s => s);

        public void Write(string content)
        {
            File.AppendAllText(filePath, content + Environment.NewLine);
        }
    }
}
