namespace SplitMergeBinaryFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            List<byte> byteList1 = new List<byte>();
            List<byte> byteList2 = new List<byte>();

            using (FileStream reader = new FileStream(sourceFilePath, FileMode.Open))
            {
                int fileSize = (int)reader.Length / 2;

                while (reader.Position != fileSize + reader.Length % 2)
                {
                    byteList1.Add((byte)reader.ReadByte());
                }

                while (reader.Position != reader.Length)
                {
                    byteList2.Add((byte)reader.ReadByte());
                }
            }

            byte[] byteArray1 = byteList1.ToArray();
            byte[] byteArray2 = byteList2.ToArray();
 
            using (FileStream writer = new FileStream(partOneFilePath,FileMode.Create))
            {
                writer.Write(byteArray1);
            }

            using (FileStream writer = new FileStream(partTwoFilePath, FileMode.Create))
            {
                writer.Write(byteArray2);
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream writer = new FileStream(joinedFilePath,FileMode.Create))
            {
                using (FileStream reader = new FileStream(partOneFilePath, FileMode.Open))
                {
                    while (reader.Position != reader.Length)
                    {
                        writer.WriteByte((byte)reader.ReadByte());
                    }
                }

                using (FileStream reader = new FileStream(partTwoFilePath,FileMode.Open))
                {
                    while (reader.Position != reader.Length)
                    {
                        writer.WriteByte((byte)reader.ReadByte());
                    }
                }
            }
        }
    }
}