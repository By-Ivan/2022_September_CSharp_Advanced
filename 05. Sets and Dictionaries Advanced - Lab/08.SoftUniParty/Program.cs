using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guestList = new HashSet<string>();
            HashSet<string> present = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                guestList.Add(input);
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            
            while (input != "END")
            {
                present.Add(input);
                input = Console.ReadLine();
            }

            Console.WriteLine(guestList.Count - present.Count);

            foreach (string student in present)
            {
                if (guestList.Contains(student))
                {
                    guestList.Remove(student);
                }
            }

            foreach (string student in guestList.OrderByDescending(x => char.IsDigit(x[0])))
            {
                Console.WriteLine(student);
            }
        }
    }
}
