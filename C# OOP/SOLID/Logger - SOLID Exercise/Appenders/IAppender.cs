using Logger.Enums;

namespace Log.Appenders
{
    public interface IAppender
    {
        public void Append(string date, ReportLevel reportLevel, string message);
    }
}
