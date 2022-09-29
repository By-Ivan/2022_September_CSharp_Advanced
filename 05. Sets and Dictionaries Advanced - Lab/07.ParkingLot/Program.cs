using System;
using System.Collections.Generic;

namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] info = input.Split(", ");

                if (info[0] == "IN")
                {
                    parking.Add(info[1]);
                }
                else if (info[0] == "OUT")
                {
                    parking.Remove(info[1]);
                }

                input = Console.ReadLine();
            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine(String.Join("\n", parking));
            }
        }
    }
}
