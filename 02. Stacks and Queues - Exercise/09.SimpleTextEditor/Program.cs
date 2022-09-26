using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> operations = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split();
                int commandName = int.Parse(cmd[0]);

                switch (commandName)
                {
                    case 1:
                        text.Append(cmd[1]);
                        operations.Push(text.ToString());
                        break;

                    case 2:
                        int count = int.Parse(cmd[1]);
                        text.Remove(text.Length - count, count);
                        operations.Push(text.ToString());
                        break;

                    case 3:
                        int index = int.Parse(cmd[1]) - 1;
                        Console.WriteLine(text.ToString()[index]);
                        break;

                    case 4:
                        operations.Pop();

                        if (operations.Count == 0)
                        {
                            text = new StringBuilder();
                        }
                        else
                        {
                            text = new StringBuilder(operations.Peek());
                        }
                        break;

                }
            }
        }
    }
}
