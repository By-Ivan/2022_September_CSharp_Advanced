namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo info = new DirectoryInfo(folderPath);

            var directories = info.GetDirectories();

            long totalSize = 0;

            foreach (FileInfo file in info.GetFiles())
            {
                totalSize += file.Length;
            }

            foreach (DirectoryInfo directory in directories)
            {
                totalSize += GetSubDirectorySize(directory);
            }

            File.WriteAllText(outputFilePath, $"{totalSize} KB");
        }

        public static long GetSubDirectorySize(DirectoryInfo dir)
        {
            long totalSize = 0;

            foreach (FileInfo file in dir.GetFiles())
            {
                totalSize += file.Length;
            }

            foreach (DirectoryInfo directory in dir.GetDirectories())
            {
                totalSize += GetSubDirectorySize(directory);
            }

            return totalSize;
        }
    }
}
