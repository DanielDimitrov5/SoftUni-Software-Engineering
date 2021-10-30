using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HttpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            const string NewLine = "\r\n";
            TcpListener tcpListener = new TcpListener(
                IPAddress.Loopback, 80);
            tcpListener.Start();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();

                using (var stream = client.GetStream())
                {
                    byte[] buffer = new byte[1000000];
                    var length = stream.Read(buffer, 0, buffer.Length);

                    string requestString =
                        Encoding.UTF8.GetString(buffer, 0, length);
                    Console.WriteLine(requestString);

                    string headHtml = File.ReadAllText(@"HeadHtml.txt");

                    var headers = requestString.Split(NewLine);

                    if (headers.First() == "POST / HTTP/1.1")
                    {
                        var userText = headers.Last();

                        AddPostToDatabase(userText);
                    }

                    StringBuilder sb = new StringBuilder();

                    var context = new PostStackContext();

                    foreach (var post in context.Posts.OrderByDescending(x => x.Id))
                    {
                        sb.Append(@$"<p>{post.Author} -> ""{post.Text}""</p>");
                    }

                    string response = "HTTP/1.1 200 OK" + NewLine +
                                      "Server: NikiServer 2020" + NewLine +
                                      "Content-Type: text/html; charset=utf-8" + NewLine +
                                      "Content-Length: " + (headHtml.Length + sb.Length) + NewLine +
                                      NewLine +
                                      headHtml + sb.ToString() + NewLine;


                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);

                    stream.Write(responseBytes);

                    Console.WriteLine(new string('=', 70));
                }

            }
        }

        private static void AddPostToDatabase(string userText)
        {
            var separatedStrings = userText.Split('&');

            var user = separatedStrings.First().Split('=').Last();
            var text = separatedStrings.Last().Split('=').Last();

            text = text.Replace('+', ' ');

            var context = new PostStackContext();

            Post post = new Post { Author = user, Text = text };

            context.Posts.Add(post);

            context.SaveChanges();
        }
    }
}
