using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] cmd = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int query = cmd[0];

                switch (query)
                {
                    case 1:
                        int element = cmd[1];
                        stack.Push(element);
                        break;

                    case 2:
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;

                    case 3:
                        if (stack.Count > 0)
                        {
                            int max = stack.ToArray().Max();
                            Console.WriteLine(max);
                        }
                        break;

                    case 4:
                        if (stack.Count > 0)
                        {
                            int min = stack.ToArray().Min();
                            Console.WriteLine(min);
                        }
                        break;
                }
            }

            stack.Reverse();

            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
