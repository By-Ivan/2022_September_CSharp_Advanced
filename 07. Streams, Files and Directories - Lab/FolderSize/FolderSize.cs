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

<<<<<<< HEAD
            var directories = info.GetDirectories();
=======
            DirectoryInfo[] directories = info.GetDirectories();
>>>>>>> 2aea4f658e962f3d791e6cffefdeb1ccccd93dad

            long totalSize = 0;

            foreach (FileInfo file in info.GetFiles())
            {
                totalSize += file.Length;
            }

            foreach (DirectoryInfo directory in directories)
            {
<<<<<<< HEAD
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
=======
                totalSize += GetFolderSize(directory);
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine($"{totalSize/1024D} KB");
            }
        }

        internal static long GetFolderSize(DirectoryInfo directory)
        {
            long size = 0;

            foreach (FileInfo file in directory.GetFiles())
            {
                size += file.Length;
            }

            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                size += GetFolderSize(dir);
            }

            return size;
>>>>>>> 2aea4f658e962f3d791e6cffefdeb1ccccd93dad
        }
    }
}
