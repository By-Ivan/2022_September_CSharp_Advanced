using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> occurances = new Dictionary<double, int>();

            foreach (double number in numbers)
            {
                if (!occurances.ContainsKey(number))
                {
                    occurances.Add(number, 0);
                }

                occurances[number]++;
            }

            foreach (var item in occurances)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
