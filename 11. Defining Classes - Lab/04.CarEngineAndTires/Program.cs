using System;
using System.IO.Compression;
using System.IO;
using System.Reflection;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Tire[] tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1,2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3)
            };

            Engine engine = new Engine(560, 6300);
            Car car = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);

            Console.WriteLine(car);

            GenerateZip();
        }
        public static void GenerateZip()
        {
            string fileName = $"..\\..\\..\\{Assembly.GetExecutingAssembly().FullName.Split(',')[0]}.zip";

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            FileInfo[] files = new DirectoryInfo(@"..\..\..\").GetFiles();

            using (var archive = ZipFile.Open(fileName, ZipArchiveMode.Create))
            {
                foreach (FileInfo file in files)
                {
                    archive.CreateEntryFromFile(file.FullName, file.Name);
                }
            }
        }
    }
}
