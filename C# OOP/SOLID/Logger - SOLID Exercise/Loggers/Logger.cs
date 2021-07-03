using Log.Appenders;
using Logger.Enums;

namespace Log.Loggers
{
    public class Logger : ILogger
    {
        private readonly IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Info(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Info, message);
        }

        public void Warning(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Warning, message);
        }

        public void Error(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Error, message);
        }
        public void Critical(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Critical, message);
        }

        public void Fatal(string date, string message)
        {
            AppendToAppenders(date, ReportLevel.Fatal, message);
        }

        private void AppendToAppenders(string date, ReportLevel report, string message)
        {
            foreach (var item in appenders)
            {
                item.Append(date, report, message);
            }
        }
    }
}
