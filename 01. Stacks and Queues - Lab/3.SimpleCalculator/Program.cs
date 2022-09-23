using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            Stack<string> output = new Stack<string>();

            string mark = "+";

            foreach (string str in input)
            {
                if (str != " " && str != "+" && str != "-")
                {
                    if (mark == "+")
                    {
                        int count = int.Parse(str);
                        while (count > 0)
                        {
                            output.Push("1");
                            count--;
                        }
                    }
                    else if (mark == "-")
                    {
                        int count = int.Parse(str);
                        while (count > 0)
                        {
                            output.Pop();
                            count--;
                        }
                    }
                    
                }
                else if (str == "+")
                {
                    mark = "+";
                }
                else if (str == "-")
                {
                    mark = "-";
                }
            }

            Console.WriteLine(output.Count);
        }
    }
}
