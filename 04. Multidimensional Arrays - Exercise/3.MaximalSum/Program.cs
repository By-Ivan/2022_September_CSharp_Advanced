using System;
using System.Linq;

namespace _3.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = currentRow[j];
                }
            }

            int maxSum = 0;
            int[,] result = new int[3, 3];

            for (int i = 0; i < rows - 2; i++)
            {
                int sum = 0;

                for (int j = 0; j < cols - 2; j++)
                {
                    sum = matrix[i, j]      + matrix[i, j + 1]      + matrix[i, j + 2]      +
                          matrix[i + 1, j]  + matrix[i + 1, j + 1]  + matrix[i + 1, j + 2]  +
                          matrix[i + 2, j]  + matrix[i + 2, j + 1]  + matrix[i + 2, j + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        result = FillResult(matrix, i, j);
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{result[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        private static int[,] FillResult(int[,] inputMatrix, int row, int col)
        {
            int[,] output = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    output[i,j] = inputMatrix[row+i, col+j];
                }
            }

            return output;
        }
    }
}
