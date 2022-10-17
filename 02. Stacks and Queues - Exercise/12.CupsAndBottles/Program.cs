using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int wastedWater = 0;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                if (bottles.Peek() >= cups.Peek())
                {
                    wastedWater += (bottles.Pop() - cups.Dequeue());
                }
                else
                {
                    int cupRemainingWater = cups.Dequeue() - bottles.Pop();
                    cups = new Queue<int>(cups.Reverse());
                    cups.Enqueue(cupRemainingWater);
                    cups = new Queue<int>(cups.Reverse());
                }
            }

            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(' ', cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
