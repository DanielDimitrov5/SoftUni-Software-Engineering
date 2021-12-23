using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Server.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string requestString)
        {
            Headers = new List<Header>();
            Cookies = new List<Cookie>();

            var lines = requestString.Split(new string[] {Constants.newLine}, StringSplitOptions.None);

            var headerLine = lines[0];

            var headerLineParts = headerLine.Split(' ');

            Method = (HttpMethod) Enum.Parse(typeof(HttpMethod), headerLineParts[0], true);

            Path = headerLineParts[1];

            int index = 1;

            bool isInHeaders = true;

            StringBuilder sb = new StringBuilder();

            while (index < lines.Length)
            {
                var line = lines[index];

                index++;

                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeaders = false;

                    continue;
                }

                if (isInHeaders)
                {
                    Headers.Add(new Header(line));
                }
                else
                {
                    sb.AppendLine(line);
                }
            }

            if (Headers.Any(x=>x.Name == Constants.RequestCookieHeader))
            {
                var cookieString = Headers.First(x => x.Name == Constants.RequestCookieHeader).Value;

                var cookies = cookieString.Split(new string[] {"; "}, StringSplitOptions.RemoveEmptyEntries);

                foreach (var cookie in cookies)
                {
                    Cookies.Add(new Cookie(cookie));
                }
            }

            Body = sb.ToString();
        }

        public string Path { get; set; }

        public HttpMethod Method { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public string Body { get; set; }
    }
}