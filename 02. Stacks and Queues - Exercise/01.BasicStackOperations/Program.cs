using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input1[0];
            int s = input1[1];
            int x = input1[2];


            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                stack.Push(input2[i]);
            }

            for (int j = 0; j < s; j++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("0");
                return;
            }

            int smallest = int.MaxValue;

            while (stack.Count > 0)
            {
                int current = stack.Pop();

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
