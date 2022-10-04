using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tiresList = new List<Tire[]>();
            List<Engine> enginesList = new List<Engine>();
            List<Car> carsList = new List<Car>();

            string input = Console.ReadLine();

            while (input != "No more tires")
            {
                string[] tireInfo = input.Split(' ');

                Tire[] tires = new Tire[4]
                {
                    new Tire(int.Parse(tireInfo[0]), double.Parse(tireInfo[1])),
                    new Tire(int.Parse(tireInfo[2]), double.Parse(tireInfo[3])),
                    new Tire(int.Parse(tireInfo[4]), double.Parse(tireInfo[5])),
                    new Tire(int.Parse(tireInfo[6]), double.Parse(tireInfo[7]))
                };

                tiresList.Add(tires);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Engines done")
            {
                string[] engineInfo = input.Split(' ');

                enginesList.Add(new Engine(int.Parse(engineInfo[0]), double.Parse(engineInfo[1])));

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Show special")
            {
                string[] carInfo = input.Split(' ');

                Car currentCar = new Car(carInfo[0], 
                                        carInfo[1], 
                                        int.Parse(carInfo[2]), 
                                        double.Parse(carInfo[3]), 
                                        double.Parse(carInfo[4]), 
                                        enginesList[int.Parse(carInfo[5])], 
                                        tiresList[int.Parse(carInfo[6])]);

                carsList.Add(currentCar);

                input = Console.ReadLine();
            }

            foreach (Car car in carsList.Where(x => x.Year >= 2017 &&
                                                x.Engine.HorsePower > 330 &&
                                                x.Tires.Sum(x=>x.Pressure) > 9 &&
                                                x.Tires.Sum(x=>x.Pressure) < 10))
            {
                car.Drive(20);

                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
