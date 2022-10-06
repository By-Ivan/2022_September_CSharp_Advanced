using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Trim().Split(' ',StringSplitOptions.RemoveEmptyEntries);

                switch (engineInfo.Length)
                {
                    case 2:
                        engines.Add(engineInfo[0],new Engine(engineInfo[0], int.Parse(engineInfo[1])));
                        break;

                    case 3:
                        bool isInt = int.TryParse(engineInfo[2], out int result);

                        if (isInt)
                        {
                            engines.Add(engineInfo[0], new Engine(engineInfo[0], int.Parse(engineInfo[1]), result));
                        }
                        else
                        {
                            engines.Add(engineInfo[0], new Engine(engineInfo[0], int.Parse(engineInfo[1]), engineInfo[2]));
                        }
                        break;

                    case 4:
                        engines.Add(engineInfo[0],new Engine(engineInfo[0], int.Parse(engineInfo[1]), int.Parse(engineInfo[2]), engineInfo[3]));
                        break;
                }
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carInfo = Console.ReadLine().Trim().Split(' ',StringSplitOptions.RemoveEmptyEntries);

                switch (carInfo.Length)
                {
                    case 2:
                        cars.Add(new Car(carInfo[0], engines[carInfo[1]]));
                        break;

                    case 3:
                        bool isInt = int.TryParse(carInfo[2], out int result);

                        if (isInt)
                        {
                            cars.Add(new Car(carInfo[0], engines[carInfo[1]], result));
                        }
                        else
                        {
                            cars.Add(new Car(carInfo[0], engines[carInfo[1]], carInfo[2]));
                        }
                        break;

                    case 4:
                        cars.Add(new Car(carInfo[0], engines[carInfo[1]], int.Parse(carInfo[2]), carInfo[3]));
                        break;
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
