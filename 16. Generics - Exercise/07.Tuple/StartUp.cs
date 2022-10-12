using System;
using System.Collections.Generic;

namespace _07.Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Tuple<string, string> tuple1 = new Tuple<string, string>();
            Tuple<string, int> tuple2 = new Tuple<string, int>();
            Tuple<int, double> tuple3 = new Tuple<int, double>();

            string[] input1 = Console.ReadLine().Split();

            tuple1.item1 = $"{input1[0]} {input1[1]}";
            tuple1.item2 = input1[2];

            string[] input2 = Console.ReadLine().Split();

            tuple2.item1 = input2[0];
            tuple2.item2 = int.Parse(input2[1]);

            string[] input3 = Console.ReadLine().Split();

            tuple3.item1 = int.Parse(input3[0]);
            tuple3.item2 = double.Parse(input3[1]);

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}
