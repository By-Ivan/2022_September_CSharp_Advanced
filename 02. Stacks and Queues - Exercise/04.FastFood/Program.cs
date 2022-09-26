using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int maxOrder = orders.Max();
            Console.WriteLine(maxOrder);
            Queue<int> ordersQueue = new Queue<int>(orders);

            if (ordersQueue.Count > 0)
            {
                while (ordersQueue.Count > 0)
                {
                    if (foodQuantity >= ordersQueue.Peek())
                    {
                        foodQuantity -= ordersQueue.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }

                if (ordersQueue.Count > 0)
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', ordersQueue)}");
                }
                else
                {
                    Console.WriteLine("Orders complete");
                }
            }
        }
    }
}
