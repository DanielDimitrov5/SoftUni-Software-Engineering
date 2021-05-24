using Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public int Battery { get; set; }

        public Tesla(string model, string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public string Start()
        {
            return Messages.StartEngine;
        }
        public string Stop()
        {
            return Messages.StopEngine;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Color} {nameof(Seat)} {Model} with {Battery} Batteries")
              .AppendLine(this.Start())
              .Append(this.Stop());

            return sb.ToString();
        }
    }
}
