using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year) 
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) 
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires) 
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make { get => make; set => make = value; }
        public string Model { get => model; set => model = value; }
        public int Year { get => year; set => year = value; }
        public double FuelQuantity { get => fuelQuantity; set => fuelQuantity = value; }
        public double FuelConsumption { get => fuelConsumption; set => fuelConsumption = value; }
        public Engine Engine { get => engine; set => engine = value; }
        public Tire[] Tires { get => tires; set => tires = value; }

        public override string ToString()
        {
            string[] tires = new string[this.Tires.Length];

            for (int i = 0; i < tires.Length; i++)
            {
                tires[i] = $"Tire {i+1}:\n" +
                    $"{this.Tires[i]}";
            }

            return $"Make: {this.Make}\n" +
                $"Model: {this.Model}\n" +
                $"Year: {this.Year}\n" +
                $"Fuel quantity: {this.fuelQuantity}\n" +
                $"Fuel consumption: {this.fuelConsumption}\n" +
                $"Engine:\n" +
                $"{this.Engine}\n" +
                $"Tires:\n" +
                $"{string.Join('\n', tires)}";
        }

        public void Drive(double distance)
        {
            if (fuelQuantity - (distance * fuelConsumption) >= 0)
            {
                fuelQuantity -= distance * fuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:f2}";
        }
    }
}
