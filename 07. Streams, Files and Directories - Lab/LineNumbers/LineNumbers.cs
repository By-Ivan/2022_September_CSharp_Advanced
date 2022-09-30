namespace LineNumbers
{
    using System.IO;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            int count = 0;
            StringBuilder stringBuilder = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                while (!reader.EndOfStream)
                {
                    stringBuilder.Append($"{count+1}. {reader.ReadLine()}\n");
                    count++;
                }

                reader.Close();
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.Write(stringBuilder.ToString());
                writer.Close();
            }
        }
    }
}
