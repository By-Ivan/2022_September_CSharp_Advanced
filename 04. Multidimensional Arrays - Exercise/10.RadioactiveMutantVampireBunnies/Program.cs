using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] field = InitializeField(size);
            char[] commands = Console.ReadLine().ToCharArray();
            int[] position = FindStartPosition(field, size);

            Dictionary<char, int[]> directions = new Dictionary<char, int[]>()
            {
                ['U'] = new int[2] { -1, 0 },
                ['D'] = new int[2] { +1, 0 },
                ['L'] = new int[2] { 0, -1 },
                ['R'] = new int[2] { 0, +1 },
            };

            for (int i = 0; i < commands.Length; i++)
            {
                if (!directions.ContainsKey(commands[i]))
                {
                    continue;
                }

                int[] newPosition = new int[2] { position[0] + directions[commands[i]][0], position[1] + directions[commands[i]][1] };

                if (PlayerEscaped(size, newPosition))
                {
                    field[position[0], position[1]] = '.';
                    field = SpreadBunnies(field, size);

                    PrintField(field, size);
                    Console.WriteLine($"won: {position[0]} {position[1]}");
                    return;

                }
                else if (field[newPosition[0], newPosition[1]] == 'B')
                {
                    field[position[0], position[1]] = '.';
                    field = SpreadBunnies(field, size);
                    PrintField(field, size);
                    Console.WriteLine($"dead: {newPosition[0]} {newPosition[1]}");
                    return;
                }
                else
                {
                    field[newPosition[0], newPosition[1]] = 'P';
                    field[position[0], position[1]] = '.';
                    position[0] = newPosition[0];
                    position[1] = newPosition[1];
                    field = SpreadBunnies(field, size);
                }

                if (field[position[0], position[1]] == 'B')
                {
                    PrintField(field, size);
                    Console.WriteLine($"dead: {position[0]} {position[1]}");
                    return;
                }
            }
        }

        private static char[,] SpreadBunnies(char[,] field, int[] size)
        {
            List<int[]> bunnyPositions = new List<int[]>();

            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    if (field[i,j] == 'B')
                    {
                        bunnyPositions.Add(new int[2] { i, j });
                    }
                }
            }

            foreach (int[] position in bunnyPositions)
            {
                for (int i = Math.Max(0, position[0] - 1); i <= Math.Min(size[0] - 1, position[0] + 1); i++)
                {
                    for (int j = Math.Max(0, position[1] - 1); j <= Math.Min(size[1] - 1, position[1] + 1); j++)
                    {
                        if (    (i == position[0] - 1 && j == position[1] - 1)
                            ||  (i == position[0] - 1 && j == position[1] + 1)
                            ||  (i == position[0] + 1 && j == position[1] - 1)
                            ||  (i == position[0] + 1 && j == position[1] + 1)
                            )
                        {
                            continue;
                        }

                        if (field[i,j] != 'B')
                        {
                            field[i, j] = 'B';
                        }
                    }
                }
            }

            return field;
        }

        private static void PrintField(char[,] field, int[] size)
        {
            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    Console.Write(field[i,j]);
                }

                Console.WriteLine();
            }
        }

        private static bool PlayerEscaped(int[] size, int[] newPosition)
        {
            for (int i = 0; i < 2; i++)
            {
                if (newPosition[i] < 0 || newPosition[i] > size[i] - 1)
                {
                    return true;
                }
            }

            return false;
        }

        private static int[] FindStartPosition(char[,] field, int[] size)
        {
            int[] output = new int[2];

            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    if (field[i, j] == 'P')
                    {
                        output[0] = i;
                        output[1] = j;
                    }
                }
            }

            return output;
        }

        private static char[,] InitializeField(int[] size)
        {
            char[,] output = new char[size[0], size[1]];

            for (int i = 0; i < size[0]; i++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();

                for (int j = 0; j < size[1]; j++)
                {
                    output[i, j] = currentRow[j];
                }
            }

            return output;
        }
    }
}
