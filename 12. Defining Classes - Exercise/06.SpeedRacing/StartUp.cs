using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(' ');

                cars.Add(new Car(info[0], double.Parse(info[1]), double.Parse(info[2])));
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] cmd = input.Split(' ');

                cars.FirstOrDefault(x => x.Model == cmd[1]).Drive(double.Parse(cmd[2]));

                input = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
