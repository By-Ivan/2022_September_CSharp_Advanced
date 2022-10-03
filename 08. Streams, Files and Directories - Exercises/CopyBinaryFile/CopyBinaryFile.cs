namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream reader = new FileStream(inputFilePath,FileMode.Open))
            {
                while (reader.Position != reader.Length)
                {
                    using (FileStream writer = new FileStream(outputFilePath, FileMode.Append))
                    {
                        writer.WriteByte((byte)reader.ReadByte());
                    }
                }
            }
        }
    }
}
