using System.Text;

using Log.Layouts;

namespace Logger.Layouts
{
    public class JSONLayout : ILayout
    {
        public string pattern
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(@" ""log"": {{");
                sb.AppendLine(@"    ""date"": ""{0}"",");
                sb.AppendLine(@"    ""level"": ""{1}"",");
                sb.AppendLine(@"    ""message"": ""{2}""");
                sb.AppendLine(@"}},");

                return sb.ToString().TrimEnd();
            }
        }
    }
}
