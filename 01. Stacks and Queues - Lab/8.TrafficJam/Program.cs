using System;
using System.Collections.Generic;

namespace _8.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> queue = new Queue<string>();
            int count = 0;

            while (command != "end")
            {
                switch (command)
                {
                    case "green":
                        for (int i = 0; i < n; i++)
                        {
                            if (queue.Count == 0)
                            {
                                break;
                            }

                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            count++;
                        }
                        break;

                    default:
                        queue.Enqueue(command);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
