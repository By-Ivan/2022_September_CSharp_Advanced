using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ');

                Engine engine = new Engine(int.Parse(carInfo[1]), int.Parse(carInfo[2]));

                Cargo cargo = new Cargo(carInfo[4], int.Parse(carInfo[3]));

                Tire[] tires = new Tire[4]
                {
                    new Tire(int.Parse(carInfo[6]), double.Parse(carInfo[5])),
                    new Tire(int.Parse(carInfo[8]), double.Parse(carInfo[7])),
                    new Tire(int.Parse(carInfo[10]), double.Parse(carInfo[9])),
                    new Tire(int.Parse(carInfo[12]), double.Parse(carInfo[11]))
                };

                Car car = new Car(carInfo[0], engine, cargo, tires);

                cars.Add(car);
            }

            switch (Console.ReadLine())
            {
                case "fragile":
                    foreach (Car car in cars.Where(x=>x.Cargo.Type == "fragile" && x.Tires.Min(x => x.Pressure) < 1))
                    {
                        Console.WriteLine(car.Model);
                    }
                    break;

                case "flammable":
                    foreach (Car car in cars.Where(x=>x.Cargo.Type == "flammable" && x.Engine.Power > 250))
                    {
                        Console.WriteLine(car.Model);
                    }
                    break;
            }
        }
    }
}
