using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            HashSet<int> result = new HashSet<int>();

            int[] sets = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < sets[0]; i++)
            {
                set1.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < sets[1]; i++)
            {
                set2.Add(int.Parse(Console.ReadLine()));
            }

            foreach (int n in set1)
            {
                if (set2.Contains(n))
                {
                    result.Add(n);
                }
            }

            foreach (int m in set2)
            {
                if (set1.Contains(m))
                {
                    result.Add(m);
                }
            }

            Console.WriteLine(String.Join(' ', result));
        }
    }
}
