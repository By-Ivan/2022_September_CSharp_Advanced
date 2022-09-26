using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool isBalanced = true;
            Stack<char> stack = new Stack<char>();

            foreach (char ch in input)
            {
                if (ch == '{' || ch == '[' || ch == '(')
                {
                    stack.Push(ch);
                }
                else if (stack.Count == 0)
                {
                    isBalanced = false;
                    break;
                }
                else if (   (stack.Peek() == '{'    && ch == '}')
                        ||  (stack.Peek() == '['    && ch == ']')
                        ||  (stack.Peek() == '('    && ch == ')')
                        )
                {
                    stack.Pop();
                }
                else
                {
                    isBalanced = false;
                    break;
                }
            }

            if (!isBalanced || stack.Count > 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
