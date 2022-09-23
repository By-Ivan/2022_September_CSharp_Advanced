using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> integers = new Stack<int>(ints);
            string input = Console.ReadLine().ToLower();

            while (input != "end")
            {
                string[] cmd = input.Split();

                switch (cmd[0])
                {
                    case "add":
                        integers.Push(int.Parse(cmd[1]));
                        integers.Push(int.Parse(cmd[2]));
                        break;

                    case "remove":
                        int count = int.Parse(cmd[1]);

                        if (integers.Count >= count)
                        {
                            while (count > 0)
                            {
                                integers.Pop();
                                count--;
                            }
                        }
                        break;
                }

                input = Console.ReadLine().ToLower();
            }

            int sum = 0;

            while (integers.Count > 0)
            {
                sum += integers.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
