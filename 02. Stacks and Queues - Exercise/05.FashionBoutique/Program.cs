using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> clothes = new Stack<int>(clothesBox);
            int sum = 0;
            int racks = 1;

            while (clothes.Count > 0)
            {
                if (clothes.Peek() + sum <= rackCapacity)
                {
                    sum += clothes.Pop();
                }
                else
                {
                    racks++;
                    sum = clothes.Pop();
                }
            }

            Console.WriteLine(racks);
        }
    }
}
