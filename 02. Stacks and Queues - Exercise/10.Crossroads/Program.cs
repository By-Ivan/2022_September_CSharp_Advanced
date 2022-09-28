using System;
using System.Collections;
using System.Collections.Generic;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int durationGreenLight = int.Parse(Console.ReadLine());
            int durationFreeWindow = int.Parse(Console.ReadLine());
            int timer = 0;
            Queue<string> road = new Queue<string>();
            int count = 0;
            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input == "green")
                {
                    if (road.Count == 0)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    Queue<char> car = new Queue<char>(road.Peek().ToCharArray());
                    timer = durationGreenLight;

                    // Green light cycle
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

                    //Free windows cycle
                    while (timer > 0)
                    {
                        if (car.Count > 0)
                        {
                            car.Dequeue();
                            timer--;
                        }
                        
                        if(car.Count == 0)
                        {
                            if (road.Count > 0)
                            {
                                road.Dequeue();
                            }

                            count++;
                            break;
                        }
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
