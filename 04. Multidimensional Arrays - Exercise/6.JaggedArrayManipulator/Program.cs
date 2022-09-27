using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            matrix = AnalyzeMatrix(matrix);

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] cmd = input.Split();
                string operation = cmd[0];
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);
                int value = int.Parse(cmd[3]);

                if (row >= 0 && row < matrix.Length)
                {
                    if (col >= 0 && col < matrix[row].Length)
                    {
                        switch (operation)
                        {
                            case "Add":
                                matrix[row][col] += value;
                                break;

                            case "Subtract":
                                matrix[row][col] -= value;
                                break;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(String.Join(' ', matrix[i]));
            }
        }

        private static int[][] AnalyzeMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] *= 2;
                        matrix[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < Math.Max(matrix[i].Length, matrix[i + 1].Length); j++)
                    {
                        if (j < matrix[i].Length)
                        {
                            matrix[i][j] /= 2;
                        }
                        if (j < matrix[i + 1].Length)
                        {
                            matrix[i + 1][j] /= 2;
                        }
                    }
                }
            }

            return matrix;
        }
    }
}
