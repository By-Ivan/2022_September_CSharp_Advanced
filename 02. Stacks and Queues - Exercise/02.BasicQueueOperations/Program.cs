using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            int[] input1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input1[0];
            int s = input1[1];
            int x = input1[2];

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(input2[i]);
            }

            for (int j = 0; j < s; j++)
            {
                queue.Dequeue();

                if (queue.Count == 0)
                {
                    Console.WriteLine("0");
                    return;
                }
            }

            int smallest = int.MaxValue;

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();

                if (current == x)
                {
                    Console.WriteLine("true");
                    return;
                }

                if (current < smallest)
                {
                    smallest = current;
                }
            }

            Console.WriteLine(smallest);
        }
    }
}
