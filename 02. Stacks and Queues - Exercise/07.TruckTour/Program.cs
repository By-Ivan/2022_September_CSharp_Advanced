using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] cmd = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(cmd);
            }

            int result = 0;

            for (int i = 0; i < queue.Count; i++)
            {
                Queue<int[]> tempQueue = new Queue<int[]>(queue);
                bool complete = true;
                int fuel = 0;

                while (tempQueue.Count > 0)
                {
                    if (fuel < 0)
                    {
                        complete = false;
                        queue.Enqueue(queue.Dequeue());
                        break;
                    }

                    int[] current = tempQueue.Dequeue();

                    fuel += (current[0] - current[1]);
                }

                if (complete)
                {
                    result = i;
                    break;
                }

            }

            Console.WriteLine(result);
        }
    }
}
