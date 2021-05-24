using Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }

        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Start()
        {
            return Messages.StartEngine;
        }
        public string Stop()
        {
            return Messages.StEngine;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} {nameof(Seat)} {Model}")
              .AppendLine(this.Start())
              .Append(this.Stop());

            return sb.ToString();
        }
    }
}
