namespace OddLines
{
    using System.Collections.Generic;
    using System.IO;
	
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            int count = 0;
            List<string> output = new List<string>();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    if (count % 2 != 0)
                    {
                        output.Add(reader.ReadLine());
                    }

                    count++;
                }

                reader.Close();
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.Write(string.Join('\n', output));
                writer.Close();
            }
        }
    }
}
