namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, List<string>> info = new Dictionary<string, List<string>>();

            foreach (FileInfo file in new DirectoryInfo(inputFolderPath).GetFiles())
            {
                if (!info.ContainsKey(file.Extension))
                {
                    info.Add(file.Extension, new List<string>());
                }

                info[file.Extension].Add($"--{file.Name} - {(double)file.Length / 1024:f2}kb");
            }
            StringBuilder output = new StringBuilder();

            foreach (KeyValuePair<string,List<string>> keyValuePair in info.OrderByDescending(x=>x.Value.Count))
            {
                output.AppendLine(keyValuePair.Key);

                foreach (string line in keyValuePair.Value.OrderBy(x=>x))
                {
                    output.AppendLine(line);
                }
            }

            return output.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            File.WriteAllText($"{desktopPath}\\{reportFileName}", textContent);
        }
    }
}
