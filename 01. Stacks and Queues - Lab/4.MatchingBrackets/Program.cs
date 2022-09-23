using System;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> positions = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    positions.Push(i);
                }
                else if (input[i] == ')')
                {
                    int index = positions.Pop();
                    Console.WriteLine(input.Substring(index, i - index + 1));
                }
            }
        }
    }
}
