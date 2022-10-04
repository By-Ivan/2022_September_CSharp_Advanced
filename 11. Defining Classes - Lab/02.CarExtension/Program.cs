using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;
            car.FuelQuantity = 30;
            car.FuelConsumption = 0.08;
            car.Drive(230);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
