using System;
using System.Linq;

namespace _8.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n == 0)
            {
                return;
            }

            int[,] matrix = PopulateMatrix(n);

            int[,] bombs = GenerateBombs(Console.ReadLine());

            matrix = ActivateBombs(matrix, bombs);

            int activeCellsCount = 0;
            int activeCellsSum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        activeCellsCount++;
                        activeCellsSum += matrix[i, j];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {activeCellsCount}");
            Console.WriteLine($"Sum: {activeCellsSum}");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }
        private static int[,] PopulateMatrix(int n)
        {
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] currentRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            return matrix;
        }

        private static int[,] GenerateBombs(string input)
        {
            string[] coordinates = input.Split(' ').ToArray();

            int[,] bombs = new int[coordinates.Length, 2];

            for (int i = 0; i < coordinates.Length; i++)
            {
                bombs[i, 0] = int.Parse(coordinates[i].Split(',')[0]);
                bombs[i, 1] = int.Parse(coordinates[i].Split(',')[1]);
            }

            return bombs;
        }

        private static int[,] ActivateBombs(int[,] matrix, int[,] bombs)
        {
            int n = (int)Math.Sqrt(matrix.Length);

            for (int i = 0; i < bombs.Length / 2; i++)
            {
                int rowBomb = bombs[i, 0];
                int colBomb = bombs[i, 1];

                if (matrix[rowBomb, colBomb] <= 0)
                {
                    continue;
                }

                for (int row = Math.Max(0, rowBomb - 1); row <= Math.Min(n - 1, rowBomb + 1); row++)
                {
                    for (int col = Math.Max(0, colBomb - 1); col <= Math.Min(n - 1, colBomb + 1); col++)
                    {
                        if (row == rowBomb && col == colBomb)
                        {
                            continue;
                        }

                        if (matrix[row, col] > 0)
                        {
                            matrix[row, col] -= matrix[rowBomb, colBomb];
                        }
                    }
                }

                matrix[rowBomb, colBomb] = 0;
            }

            return matrix;
        }
    }
}
