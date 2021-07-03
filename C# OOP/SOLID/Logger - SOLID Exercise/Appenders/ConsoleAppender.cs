using Log.Layouts;
using Logger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Log.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (CanAppend(reportLevel))
            {
                AppendedMessages++;

                string content = string.Format(layout.pattern, date, reportLevel, message);

                Console.WriteLine(content);
            }
        }
    }
}
