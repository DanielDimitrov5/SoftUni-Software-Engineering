namespace Crossroads
{
    using System;
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
                    while (true)
                    {
                        currentGreen -= queuedCars.Peek().Length;

                        if (currentGreen >= 0)
                        {
                            queuedCars.Dequeue();

                            carPassed++;
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
                                //accident
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{queuedCars.Dequeue()} was hit at ---.");
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
