using System;

namespace TradeComission
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double comission = 0;
            if (sales >= 0)
            {
                switch (town)
                {
                    case "Sofia":
                        if (sales >= 0 && sales <= 500)
                        {
                            comission = 0.05;
                        }
                        else if (sales > 500 && sales <= 1000)
                        {
                            comission = 0.07;
                        }
                        else if (sales > 1000 && sales <= 10000)
                        {
                            comission = 0.08;
                        }
                        else
                        {
                            comission = 0.012;
                        }
                        break;
                    case "Varna":
                        if (sales >= 0 && sales <= 500)
                        {
                            comission = 0.045;
                        }
                        else if (sales > 500 && sales <= 1000)
                        {
                            comission = 0.075;
                        }
                        else if (sales > 1000 && sales <= 10000)
                        {
                            comission = 0.1;
                        }
                        else
                        {
                            comission = 0.013;
                        }
                        break;
                    case "Plovdiv":
                        if (sales >= 0 && sales <= 500)
                        {
                            comission = 0.055;
                        }
                        else if (sales > 500 && sales <= 1000)
                        {
                            comission = 0.08;
                        }
                        else if (sales > 1000 && sales <= 10000)
                        {
                            comission = 0.012;
                        }
                        else if (sales > 10000)
                        {
                            comission = 0.0145;
                        };
                        break;
                    default:
                        Console.WriteLine("error");
                        break;

                }
                double result = comission * sales;
                if (result > 0)
                {
                    Console.WriteLine($"{result:f2}");
                }
                //Console.WriteLine($"{result:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }
            
            

        }
    }
}

