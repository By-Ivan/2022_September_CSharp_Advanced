namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.IO;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder input = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int count = 0;

                while (!reader.EndOfStream)
                {
                    Stack<string> line = new Stack<string>(reader.ReadLine().Split(' '));

                    if (count % 2 == 0)
                    {
                        input.AppendLine(string.Join(' ',line));
                    }

                    count++;
                }
            }

            foreach (char ch in new char[] { '-', ',', '.', '!', '?' })
            {
                input = input.Replace(ch, '@');
            }

            return input.ToString();
        }
    }
}
