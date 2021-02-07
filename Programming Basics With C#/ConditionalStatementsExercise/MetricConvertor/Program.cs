using System;

namespace MetricConvertor
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            string inputMetric = Console.ReadLine();
            string outputMetric = Console.ReadLine();

            double result = 0;

            if (inputMetric == "mm" && outputMetric == "cm")
            {
                result = num / 10;
            }
            else if (inputMetric == "mm" && outputMetric == "m")
            {
                result = num / 1000;
            }
            else if (inputMetric == "cm" && outputMetric == "mm")
            {
                result = num * 10;
            }
            else if (inputMetric == "cm" && outputMetric == "m")
            {
                result = num / 100;
            }
            else if (inputMetric == "m" && outputMetric == "mm")
            {
                result = num * 1000;
            }
            else if (inputMetric == "m" && outputMetric == "cm")
            {
                result = num * 100;
            }
            Console.WriteLine($"{result:f3}");
        }
    }
}
