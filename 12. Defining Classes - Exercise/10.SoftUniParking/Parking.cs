using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;

        private Dictionary<string, Car> cars;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            cars = new Dictionary<string, Car>();
        }

        public int Count { get => cars.Count; }

        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (Count == capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car.RegistrationNumber, car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!cars.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(registrationNumber);

            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
            => cars.ContainsKey(registrationNumber) ? cars[registrationNumber] : null;

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string reg in registrationNumbers)
            {
                if (cars.ContainsKey(reg))
                {
                    cars.Remove(reg);
                }
            }
        }
    }
}
