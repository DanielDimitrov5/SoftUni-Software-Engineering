using System;
using System.Runtime.InteropServices;

namespace fruitShop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double prise = 0;
            if (fruit == "apple" || fruit == "orange" || fruit == "grapes" || fruit == "kiwi"
                || fruit == "grapefruit" || fruit == "banana" || fruit == "pineapple")
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        switch (fruit)
                        {
                            case "apple":
                                prise = 1.20;
                                break;
                            case "banana":
                                prise = 2.50;
                                break;
                            case "pineapple":
                                prise = 5.50;
                                break;
                            case "orange":
                                prise = 0.85;
                                break;
                            case "grapes":
                                prise = 3.85;
                                break;
                            case "kiwi":
                                prise = 2.70;
                                break;
                            default:
                                prise = 1.45;
                                break;
                        }
                        break;
                    case "Saturday":
                    case "Sunday":
                        switch (fruit)
                        {
                            case "apple":
                                prise = 1.25;
                                break;
                            case "banana":
                                prise = 2.70;
                                break;
                            case "pineapple":
                                prise = 5.60;
                                break;
                            case "orange":
                                prise = 0.90;
                                break;
                            case "grapes":
                                prise = 4.20;
                                break;
                            case "kiwi":
                                prise = 3;
                                break;
                            default:
                                prise = 1.60;
                                break;

                        }
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }

            }
            else
            {
                Console.WriteLine("error");
            }
            double totalPrise = prise * quantity;
            if (totalPrise > 0)
            {
                Console.WriteLine($"{totalPrise:f2}");
            }
            
            
        }
    }
} 