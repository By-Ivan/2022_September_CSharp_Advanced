using System;

namespace _08.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Threeuple<string, string, string> threeuple1 = new Threeuple<string, string, string>();
            Threeuple<string, int, bool> threeuple2 = new Threeuple<string, int, bool>();
            Threeuple<string, double, string> threeuple3 = new Threeuple<string, double, string>();

            string[] input1 = Console.ReadLine().Split();

            threeuple1.Item1 = string.Join(' ', input1, 0, 2);
            threeuple1.Item2 = input1[2];
            threeuple1.Item3 = string.Join(' ', input1, 3, input1.Length - 3);

            string[] input2 = Console.ReadLine().Split();

            threeuple2.Item1 = input2[0];
            threeuple2.Item2 = int.Parse(input2[1]);
            threeuple2.Item3 = input2[2] == "drunk" ? true : false;

            string[] input3 = Console.ReadLine().Split();

            threeuple3.Item1 = input3[0];
            threeuple3.Item2 = double.Parse(input3[1]);
            threeuple3.Item3 = input3[2];

            Console.WriteLine(threeuple1);
            Console.WriteLine(threeuple2);
            Console.WriteLine(threeuple3);
        }
    }
}
