using System.Text;

using Log.Layouts;

namespace Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        public string pattern
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("<log>");
                sb.AppendLine(" <date>{0}</date>");
                sb.AppendLine(" <level>{1}</level>");
                sb.AppendLine(" <message>{2}</message>");
                sb.AppendLine("</log>");

                return sb.ToString().TrimEnd();
            }
        }
    }
}
