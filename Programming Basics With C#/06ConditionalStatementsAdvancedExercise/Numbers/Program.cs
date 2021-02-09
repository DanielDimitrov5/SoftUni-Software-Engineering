using System;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            string operant = Console.ReadLine();
            string EvenOrOdd = "";
            double result = 0;
            if (operant == "+")
            {
                result = n1 + n2;
            }
            else if (operant == "-")
            {
                result = n1 - n2;
            }
            else if (operant == "/" && n2 != 0)
            {
                result = n1 / n2;
            }
            else if (operant == "*")
            {
                result = n1 * n2;
            }
            else if (operant == "%" && n2 != 0)
            {
                result = n1 % n2;
            }
            if ((operant == "+" || operant == "-" || operant == "*") && result % 2 == 0)
            {
                EvenOrOdd = "even";
            }
            else if ((operant == "+" || operant == "-" || operant == "*") && result % 2 != 0)
            {
                EvenOrOdd = "odd";
            }
            if (operant == "+" || operant == "-" || operant == "*")
            {
                Console.WriteLine($"{n1} {operant} {n2} = {result} - {EvenOrOdd}");
            }
            else if (operant == "/" && result != 0)
            {
                Console.WriteLine($"{n1} / {n2} = {result:f2}");
            }
            else if (n2 == 0 && (operant == "/" || operant == "%"))
            {
                Console.WriteLine($"Cannot divide {n1} by zero");
            }
            else
            {
                Console.WriteLine($"{n1} % {n2} = {result}");
            }
        }
    }
}
