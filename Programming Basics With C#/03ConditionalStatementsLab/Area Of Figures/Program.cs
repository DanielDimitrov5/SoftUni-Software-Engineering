using System;

namespace Area_Of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            if (figure == "square")
            {
                double side = double.Parse(Console.ReadLine());
                double area = side * side;
                Console.WriteLine("{0:F3}", area);
            }
            if (figure == "rectangle")
            {
                double lenght = double.Parse(Console.ReadLine());
                double widht = double.Parse(Console.ReadLine());
                double area = lenght * widht;
                Console.WriteLine("{0:F3}", area);
            }
            if (figure == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double area = r * r * Math.PI;
                Console.WriteLine("{0:F3}", area);
            } 
            if (figure == "triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double hight = double.Parse(Console.ReadLine());
                double area = side * hight / 2;
                Console.WriteLine("{0:F3}", area);

            }


        }
    }
}
