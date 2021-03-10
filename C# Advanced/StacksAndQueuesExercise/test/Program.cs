namespace Crossroads
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            int carPassed = 0;

            Queue<string> queuedCars = new Queue<string>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                int currentGreen = greenLightDuration;
                int currentWindow = freeWindow;

                if (command == "green")
                {
                    while (queuedCars.Any())
                    {
                        currentGreen -= queuedCars.Peek().Length;

                        if (currentGreen >= 0)
                        {
                            queuedCars.Dequeue();

                            carPassed++;

                            if (currentGreen == 0)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (currentGreen + currentWindow >= 0)
                            {
                                queuedCars.Dequeue();

                                carPassed++;

                                break;
                            }
                            else
                            {
                                Console.WriteLine("A crash happened!");

                                int hitIndex = (queuedCars.Peek().Length - 1) - (Math.Abs(currentGreen + currentWindow) - 1);

                                Console.WriteLine($"{queuedCars.Peek()} was hit at {queuedCars.Dequeue()[hitIndex]}.");

                                Environment.Exit(0);
                            }
                        }
                    }
                }
                else
                {
                    queuedCars.Enqueue(command);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carPassed} total cars passed the crossroads.");
        }
    }
}
