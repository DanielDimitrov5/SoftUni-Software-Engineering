using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
            Displacement = -1;
            Efficienty = null;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficienty { get; set; }
    }
}
