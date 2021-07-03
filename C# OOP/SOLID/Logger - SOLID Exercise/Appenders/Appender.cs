using Log.Layouts;
using Logger.Enums;
using System.Text;

namespace Log.Appenders
{
    public abstract class Appender : IAppender
    {
        protected ILayout layout;

        public Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        protected int AppendedMessages { get; set; }

        public abstract void Append(string date, ReportLevel reportLevel, string message);

        protected bool CanAppend(ReportLevel reportLevel)
        {
            return reportLevel >= ReportLevel;
        }

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {layout.GetType().Name}, Report level: {ReportLevel}, Messages appended: {AppendedMessages}";
        }
    }
}
