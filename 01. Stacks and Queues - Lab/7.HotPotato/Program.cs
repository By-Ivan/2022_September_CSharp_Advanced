using System;
using System.Collections.Generic;

namespace _7.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Queue<string> participants = new Queue<string>(input);
            int toss = int.Parse(Console.ReadLine());

            while (participants.Count > 1)
            {
                for (int i = 1; i < toss; i++)
                {
                    participants.Enqueue(participants.Dequeue());
                }

                Console.WriteLine($"Removed {participants.Dequeue()}");
            }

            Console.WriteLine($"Last is {participants.Dequeue()}");
        }
    }
}
