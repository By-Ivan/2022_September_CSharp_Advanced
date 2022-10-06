using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace _08.CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
            Displacement = -1;
            Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement) : this (model,power)
        {
            Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency) : this (model,power)
        {
            Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
        {
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            string displacement = Displacement == -1 ? "n/a" : Displacement.ToString();

            return $"{Model}:\n    Power: {Power}\n    Displacement: {displacement}\n    Efficiency: {Efficiency}";
        }
    }
}
