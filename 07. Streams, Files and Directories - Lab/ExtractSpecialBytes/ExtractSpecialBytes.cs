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
                    bytes.Add(byte.Parse(reader.ReadLine()));
                }
            }

            using (FileStream reader = new FileStream(binaryFilePath, FileMode.Open))
            {
                while (reader.Position != reader.Length)
                {
                    int currentByte = reader.ReadByte();

                    foreach (byte bt in bytes)
                    {
                        if (bt == currentByte)
                        {
                            using (FileStream writer = new FileStream(outputPath, FileMode.Create))
                            {
                                writer.WriteByte(bt);
                            }

                            break;
                        }
                    }
                }
            }
        }
    }
}
