using System;

using CustomLog.Loggers;
using Log.Appenders;
using Log.Layouts;
using Log.Loggers;
using Logger.Enums;
using Logger.Layouts;

namespace Logger.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            IAppender[] appenders = new IAppender[n];

            for (int i = 0; i < n; i++)
            {
                string[] appeneders = Console.ReadLine().Split();

                string appenderType = appeneders[0];
                string layoutType = appeneders[1];
                ReportLevel reportLevel = appeneders.Length == 3 
                    ? Enum.Parse<ReportLevel>(appeneders[2], true) 
                    : ReportLevel.Info;

                ILayout layout = LayoutCreator(layoutType);

                IAppender appender = AppenderCreator(appenderType, layout, reportLevel);

                appenders[i] = appender;
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split('|');

                string reportLevel = tokens[0];
                string date = tokens[1];
                string message = tokens[2];

                ILogger logger = new Log.Loggers.Logger(appenders);

                switch (reportLevel.ToLower())
                {
                    case "info": logger.Info(date, message); break;
                    case "warning": logger.Warning(date, message); break;
                    case "error": logger.Error(date, message); break;
                    case "critical": logger.Critical(date, message); break;
                    case "fatal": logger.Fatal(date, message); break;
                }
            }

            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender.ToString());
            }
        }

        private IAppender AppenderCreator(string type, ILayout layout, ReportLevel reportLevel)
        {
            IAppender appender = null;

            switch (type)
            {
                case nameof(ConsoleAppender):

                    appender = new ConsoleAppender(layout) { ReportLevel = reportLevel };

                    break;
                case nameof(FileAppender):

                    appender = new FileAppender(layout, new LogFile()) { ReportLevel = reportLevel };

                    break;
            }

            return appender;
        }

        private ILayout LayoutCreator(string type)
        {
            ILayout layout = null;

            switch (type)
            {
                case nameof(SimpleLayout):

                    layout = new SimpleLayout();

                    break;

                case nameof(XmlLayout):

                    layout = new XmlLayout();

                    break;
            }

            return layout;
        }
    }
}
