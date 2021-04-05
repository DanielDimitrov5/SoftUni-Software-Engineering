using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = -1;
            Color = null;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Model + ':');
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.Power}");

            string disp = "n/a";

            var ternaryDisp = Engine.Displacement != -1 ? disp = Engine.Displacement.ToString() : null;

            sb.AppendLine($"    Displacement: {disp}");

            string efficiency = "n/a";

            string ternaryEfficiency = Engine.Efficienty != null ? efficiency = Engine.Efficienty : null;

            sb.AppendLine($"    Efficiency: {efficiency}");

            string weight = "n/a";

            var ternaryWight = Weight != -1 ? weight = Weight.ToString() : null;

            sb.AppendLine($"  Weight: {weight}");

            string color = "n/a";

            var ternaryColor = Color != null ? color = Color : null;

            sb.Append($"  Color: {color}");

            return sb.ToString();
        }
    }
}
