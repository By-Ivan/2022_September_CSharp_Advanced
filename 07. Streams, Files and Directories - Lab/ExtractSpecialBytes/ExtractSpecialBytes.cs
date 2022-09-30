namespace ExtractSpecialBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            List<int> bytes = new List<int>();

            using (StreamReader reader = new StreamReader(bytesFilePath))
            {
                while (!reader.EndOfStream)
                {
                    bytes.Add(int.Parse(reader.ReadLine()));
                }

                reader.Close();
            }

            byte[] byteArray = GetByteArray(bytesFilePath);
        }

        private static byte[] GetByteArray(string bytesFilePath)
        {
            using (FileStream fileStream = new FileStream(bytesFilePath, FileMode.Open, FileAccess.Read))
            {
                int streamLength = (int)fileStream.Length;
                byte[] byteArray = new byte[fileStream.Length];
                int currentBytePosition = 0;
                while (streamLength > 0)
                {
                    int n = fileStream.Read(byteArray, currentBytePosition, streamLength);

                    if (n == 0)
                    {
                        break;
                    }

                    currentBytePosition += n;
                    streamLength -= n;
                }

                fileStream.Close();

                return byteArray;
            }
        }
    }
}
