namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] input = File.ReadAllLines(inputFilePath);
            string[] output = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                output[i] = $"Line {i+1}: {input[i]} ({input[i].Count(x => char.IsLetter(x))})({input[i].Count(x => char.IsPunctuation(x))})";
            }

            File.WriteAllLines(outputFilePath,output);
        }
    }
}
