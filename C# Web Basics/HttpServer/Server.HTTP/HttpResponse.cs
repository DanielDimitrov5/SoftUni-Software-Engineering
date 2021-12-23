using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Server.HTTP
{
    public class HttpResponse
    {
        public HttpResponse(string contentType, byte[] body, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (body is null)
            {
                throw new ArgumentException(nameof(body));
            }

            StatusCode = statusCode;
            Body = body;
            Headers = new List<Header>()
            {
                {new Header("Content-Type", contentType)},
                {new Header("Content-Length", body.Length.ToString())}
            };
            Cookies = new List<Cookie>();
        }

        public HttpStatusCode StatusCode { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public byte[] Body { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}" + Constants.newLine);
            foreach (var header in this.Headers)
            {
                sb.Append(header.ToString() + Constants.newLine);
            }

            foreach (var cookie in this.Cookies)
            {
                sb.Append("Set-Cookie: " + cookie.ToString() + Constants.newLine);
            }

            sb.Append(Constants.newLine);

            return sb.ToString();
        }
    }
}