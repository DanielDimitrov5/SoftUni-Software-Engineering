using System;
using System.IO;
using System.Linq;
using System.Text;
using Server.HTTP;
using System.Threading.Tasks;

namespace MvsApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var server = new HttpServer();

            server.AddRoute("/", HomePage);

            server.AddRoute("/1", PageOne);

            await server.StartAsync(80);
        }

        private static HttpResponse HomePage(HttpRequest request)
        {
            var html = "<h1>Hi!</h1>";

            var responseBodyBytes = Encoding.UTF8.GetBytes(html);

            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
        private static HttpResponse PageOne(HttpRequest arg)
        {
            var html = "<h1>Hi again!</h1>";
            //var html = File.ReadAllText("C:\\Users\\USER\\Desktop\\test.github.io\\index.html");

            var responseBodyBytes = Encoding.UTF8.GetBytes(html);

            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
