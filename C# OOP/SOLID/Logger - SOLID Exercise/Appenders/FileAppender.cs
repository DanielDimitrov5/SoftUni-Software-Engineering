using Log.Layouts;
using CustomLog.Loggers;
using Logger.Enums;

namespace Log.Appenders
{
    public class FileAppender : Appender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (CanAppend(reportLevel))
            {
                AppendedMessages++;

                string content = string.Format(layout.pattern, date, reportLevel, message);

                this.logFile.Write(content);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", {this.logFile.Size}";
        }
    }
}
