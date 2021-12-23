using System.Text;

namespace Server.HTTP
{
    public class ResponseCookie : Cookie
    {
        public ResponseCookie(string name, string value)
            : base(name, value)
        { 
            Path = "/";
        }

        public int MaxAge { get; set; }

        public bool HttpOnly { get; set; }

        public string Path { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{Name}={Value}; Path={Path};");

            if (MaxAge != 0)
            {
                sb.Append($" Max-Age={MaxAge};");
            }

            if (HttpOnly)
            {
                sb.Append(" HttpOnly;");
            }

            return sb.ToString();
        }
    }
}