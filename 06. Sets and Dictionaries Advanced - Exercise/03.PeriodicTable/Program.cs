using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            SortedSet<string> mendeleevTable = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                foreach (string element in Console.ReadLine().Split())
                {
                    mendeleevTable.Add(element);
                }
            }

            Console.WriteLine(string.Join(' ',mendeleevTable));
        }
    }
}
