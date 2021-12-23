using System;

namespace Server.HTTP
{
    public class Header
    {
        public Header(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public Header(string headerLine)
        {
            var headerParts = headerLine.Split(new string[] { ": " },
                2, StringSplitOptions.None);
            Name = headerParts[0];
            Value = headerParts[1];
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {this.Value}";
        }
    }
}