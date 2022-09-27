using System;
using System.Collections;
using System.Collections.Generic;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Seconds in [1-100] range
            int durationGreenLight = int.Parse(Console.ReadLine());
            // Seconds in [0-100] range
            int durationFreeWindow = int.Parse(Console.ReadLine());

            Queue<string> road = new Queue<string>();

            int count = 0;

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input == "green")
                {
                    int timer = durationGreenLight;

                    if (road.Count == 0)
                    {
                        continue;
                    }

                    Queue<char> car = new Queue<char>(road.Peek().ToCharArray());

                    while (timer > 0)
                    {
                        if (car.Count == 0)
                        {
                            road.Dequeue();

                            if (road.Count == 0)
                            {
                                break;
                            }

                            car = new Queue<char>(road.Peek().ToCharArray());
                            count++;
                        }

                        car.Dequeue();
                        timer--;
                    }

                    timer = durationFreeWindow;

                    while (timer > 0)
                    {
                        if (car.Count == 0)
                        {
                            count++;
                            break;
                        }

                        car.Dequeue();
                        timer--;
                    }

                    if (car.Count > 0)
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{road.Dequeue()} was hit at {car.Dequeue()}.");
                        return;
                    }
                }
                else
                {
                    road.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{count} total cars passed the crossroads.");
        }
    }
}
