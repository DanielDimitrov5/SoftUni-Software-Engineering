namespace CustomLog.Loggers
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string s);
    }
}
