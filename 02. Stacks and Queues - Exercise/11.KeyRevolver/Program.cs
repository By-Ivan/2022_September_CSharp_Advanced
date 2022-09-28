using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int intelligence = int.Parse(Console.ReadLine());
            int bulletsInitialCount = bullets.Count;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                for (int i = 0; i < barrelSize; i++)
                {
                    int currentBullet = bullets.Pop();
                    int currentLock = locks.Peek();

                    if (currentBullet <= currentLock)
                    {
                        Console.WriteLine("Bang!");
                        locks.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }

                    if (bullets.Count == 0 || locks.Count == 0)
                    {
                        break;
                    }
                }

                if (bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (bullets.Count == 0 && locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - ((bulletsInitialCount - bullets.Count) * bulletPrice)}");
            }
        }
    }
}
