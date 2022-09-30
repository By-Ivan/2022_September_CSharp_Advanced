using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _9.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(' ');
            char[,] field = InitializeField(n);
            int totalCoals = 0;
            int countCoals = 0;
            int currentRow = 0;
            int currentCol = 0;

            Dictionary<string, int[]> directions = new Dictionary<string, int[]>()
            {
                ["up"] = new int[2] { -1, 0 },
                ["down"] = new int[2] { +1, 0 },
                ["left"] = new int[2] { 0, -1 },
                ["right"] = new int[2] { 0, +1 },
            };

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (field[i, j] == 's')
                    {
                        currentRow = i;
                        currentCol = j;
                    }
                    else if (field[i, j] == 'c')
                    {
                        totalCoals++;
                    }
                }
            }

            for (int i = 0; i < commands.Length; i++)
            {
                if (!directions.ContainsKey(commands[i]))
                {
                    continue;
                }

                int rowNew = directions[commands[i]][0] + currentRow;
                int colNew = directions[commands[i]][1] + currentCol;

                if (rowNew > n - 1 ||  colNew > n - 1 ||  rowNew < 0 ||  colNew < 0)
                {
                    continue;
                }
                else if (field[rowNew,colNew] == 'e')
                {
                    Console.WriteLine($"Game over! ({rowNew}, {colNew})");
                    return;
                }
                else if (field[rowNew,colNew] == 'c')
                {
                    countCoals++;
                    totalCoals--;
                    field[rowNew, colNew] = '*';
                    currentRow = rowNew;
                    currentCol = colNew;

                    if (totalCoals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                        return;
                    }
                }
                else if (i == commands.Length - 1)
                {
                    Console.WriteLine($"{totalCoals} coals left. ({rowNew}, {colNew})");
                    return;
                }
                else
                {
                    currentRow = rowNew;
                    currentCol = colNew;
                }
            }

            Console.WriteLine($"{totalCoals} coals left. ({currentRow}, {currentCol})");
        }

        private static char[,] InitializeField(int n)
        {
            char[,] field = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                char[] symbols = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    field[i, j] = symbols[j];
                }
            }

            return field;
        }
    }
}
