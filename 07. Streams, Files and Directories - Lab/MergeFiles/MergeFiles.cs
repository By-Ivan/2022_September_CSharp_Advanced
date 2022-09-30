namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            string[][] input = new string[2][];

            using (StreamReader reader = new StreamReader(firstInputFilePath))
            {
                input[0] = reader.ReadToEnd().Split(Environment.NewLine);
                reader.Close();
            }

            using (StreamReader reader = new StreamReader(secondInputFilePath))
            {
                input[1] = reader.ReadToEnd().Split(Environment.NewLine);
                reader.Close();
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                for (int i = 0; i < Math.Min(input[0].Length, input[1].Length); i++)
                {
                    writer.WriteLine(input[0][i]);
                    writer.WriteLine(input[1][i]);
                }

                for (int i = Math.Min(input[0].Length, input[1].Length); i < Math.Max(input[0].Length, input[1].Length); i++)
                {
                    int index = input[0].Length > input[1].Length ? 0 : 1;

                    writer.WriteLine(input[index][i]);
                }

                writer.Close();
            }
        }
    }
}
